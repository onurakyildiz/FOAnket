using Anket_Projesi_Ford_Otosan.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Anket_Projesi_Ford_Otosan.Controllers;

namespace Anket_Projesi_Ford_Otosan.Controllers
{
    
    public class AnketlerController : Controller
    {
        ANKET_DBEntities db = new ANKET_DBEntities();

        // GET: Anketler
        public ActionResult Index(ANK_CALISANLAR au)
        {
            try
            {
                //Kullanıcının Giriş Kontrolü
                string user = au.CH_KUL_ADI;
                string pass = au.CH_SIFRE;
                var test = Session["CH_KUL_ADI"];
                var stest = Session["CH_SIFRE"];
                ViewBag.Yetki = Session["SW_YETKI"];
                using (db)
                {
                    string status;
                    var usr = (from e in db.ANK_CALISANLAR where e.CH_KUL_ADI == test && e.CH_SIFRE==stest select e).FirstOrDefault();
                   
                    if (Session["CH_KUL_ADI"].ToString() != test)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //Anket Listeleme
                        Anket anketlist = new Anket();
                        List<ANK_ANKETLER> list1 = db.ANK_ANKETLER.ToList();
                        List<ANK_SORULAR> list2 = db.ANK_SORULAR.ToList();
                        anketlist.AnketList = new Tuple<List<ANK_ANKETLER>,List<ANK_SORULAR>>(list1,list2);
                        return View(anketlist); 
                    }

                }
                //if (Session["CH_KUL_ADI"].ToString() != user)
                //{ return RedirectToAction("Index", "Home"); }
                //else { return View(); }
                
                

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");

            }


        }

        [HttpPost]
        public ActionResult Cevapla(int SQ_ANKET_ID)
        {
            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 2000000 };
            ////ANK_ANKETLER model = db.ANK_ANKETLER.Where(x => x.SQ_ANKET_ID == SQ_ANKET_ID).SingleOrDefault();
            ////string value = string.Empty;
            ////value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            ////{
            ////    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ////});
            ////var serialized = serializer.Serialize(value);
            ////return Json(value,JsonRequestBehavior.AllowGet);
            int soruid = db.ANK_SORULAR.Where(x => x.CD_ANKET_ID == SQ_ANKET_ID).Select(x => new { id = x.SQ_SORU_ID }).FirstOrDefault().id;

            int id;
            var model = db.ANK_ANKETLER.Where(x => x.SQ_ANKET_ID == SQ_ANKET_ID).Select(x => new { id = x.SQ_ANKET_ID, title = x.CH_ANKET, sorular = db.ANK_SORULAR.Where(m => m.CD_ANKET_ID == SQ_ANKET_ID).Select(m => new { soru = m.CH_SORU, soruturu = m.CD_REF_ID,snumara=m.SQ_SORU_ID }), cevaplar = db.ANK_SECENEKLER.Where(y => y.CD_ANKET_ID== SQ_ANKET_ID).Select(y => new { secid=y.SQ_SECENEK_ID,cevap = y.CH_SECENEK,sid=y.CD_SORU_ID }) }).FirstOrDefault();
            var serialized = serializer.Serialize(model);
            return Json(new JsonResult { Data = serialized }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult CevapKaydet(cevapbilgiler model)
        {
            var isno = Request.Cookies["isno"].Value;
            var cevaplar = new ANK_CEVAPLAR { CD_SECENEK_ID = model.CD_SECENEK_ID, CD_SORU_ID = model.CD_SORU_ID, CD_CEVAPLAYAN_KISI = Convert.ToInt32(isno), CH_BILGI = model.CH_BILGI, CD_REF_ID = model.CD_REF_ID };
            db.ANK_CEVAPLAR.Add(cevaplar);
            db.SaveChanges();
            return Json("OK");
        }

    }
}