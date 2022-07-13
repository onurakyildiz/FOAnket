using Anket_Projesi_Ford_Otosan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Anket_Projesi_Ford_Otosan.Controllers
{
    public class AnketOlusturController : Controller
    {
        // GET: AnketOlustur
        ANKET_DBEntities db = new ANKET_DBEntities();

        
        public ActionResult Index(ANK_CALISANLAR au)
        {
            try
            {
                string user = au.CH_KUL_ADI;
                string pass = au.CH_SIFRE;
                int id = au.SQ_IS_NO;
                var test = Session["CH_KUL_ADI"];
                var stest = Session["CH_SIFRE"];
                var ıd = Convert.ToInt32(Session["SQ_IS_NO"]);
                bool yetki = Convert.ToBoolean(Session["SW_YETKI"]);
                
                using (db)
                {
                    string status;
                    var usr = (from e in db.ANK_CALISANLAR where e.CH_KUL_ADI == test && e.CH_SIFRE==stest && e.SW_YETKI==true select e.SQ_IS_NO).FirstOrDefault();

                    if (Session["CH_KUL_ADI"].ToString() != test && Session["CH_SIFRE"].ToString()!=stest && yetki!=true)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        //DropDown'a Veri Çekme
                        var sorgu = from x in db.ANK_REFERANSLAR 
                                    select new DropdownDoldurma{ CH_REF_ANAHTAR=x.CH_REF_ANAHTAR,SQ_REF_ID=x.SQ_REF_ID,CH_REF_ACIKLAMA=x.CH_REF_ACIKLAMA };
                        return View(sorgu.ToList());
                    }
                }


                
                
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public JsonResult AnketKaydet(AnketKaydetme model)
        {
            var result = false;
            try
            {


                ANK_ANKETLER stu = db.ANK_ANKETLER.SingleOrDefault(x => x.SQ_ANKET_ID == model.SQ_ANKET_ID);

                //Kullanıcının İş Numrasını Çekme
                var isno = TempData["IsNo"];

                //Anketler Tablosu Kayıt 
                var anket = new ANK_ANKETLER { CH_ANKET = model.CH_ANKET, DT_OLUS_TARIHI = DateTime.Now, DT_YAYIN_TARIHI = model.DT_YAYIN_TARIHI, DT_BITIS_TARIHI = model.DT_BITIS_TARIHI, CD_OLUS_KISI = Convert.ToInt16(isno), CD_GUNC_KISI = Convert.ToInt16(isno), DT_GUNC_TARIHI = DateTime.Now };

                db.ANK_ANKETLER.Add(anket);
                db.SaveChanges();


                //Oluşturulan Anketin Id'sini çekme
                var anketId = anket.SQ_ANKET_ID;

                
                int ref_id = model.CD_REF_ID;
                
                if (ref_id == 9)
                {//----Seçenekli sorular için kayıt----
                    var soru=new ANK_SORULAR { CD_ANKET_ID = anketId, CH_SORU = model.CH_SORU, DT_EKL_TARIHI = DateTime.Now, CD_EKL_KISI = Convert.ToInt16(isno), CD_GUNC_KISI = Convert.ToInt16(isno), DT_GUNC_TARIHI = DateTime.Now, CD_REF_ID = ref_id };
                    db.ANK_SORULAR.Add(soru);
                    db.SaveChanges();
                    var soruID = soru.SQ_SORU_ID;
                    db.ANK_SECENEKLER.Add(new ANK_SECENEKLER {CD_SORU_ID=soruID,CH_SECENEK=model.CH_SECENEK,DT_EKL_TARIHI=DateTime.Now,CD_EKL_KISI=Convert.ToInt32(isno),DT_GUNC_TARIHI=DateTime.Now,CD_GUNC_KISI=Convert.ToInt32(isno) });
                    db.SaveChanges();
                }
                else if (ref_id == 8)
                {
                    //----Açıklamalı sorular için kayıt----
                    var soru = new ANK_SORULAR { CD_ANKET_ID = anketId, CH_SORU = model.CH_SORU, DT_EKL_TARIHI = DateTime.Now, CD_EKL_KISI = Convert.ToInt16(isno), CD_GUNC_KISI = Convert.ToInt16(isno), DT_GUNC_TARIHI = DateTime.Now, CD_REF_ID = ref_id };
                    db.ANK_SORULAR.Add(soru);
                    db.SaveChanges();
                }
                //Sorular Tablosu Kayıt
                if (ViewBag.IkiliSecim == "true")
                {
                    db.ANK_SORULAR.Add(new ANK_SORULAR { CD_ANKET_ID = anketId, CH_SORU = model.CH_SORU, DT_EKL_TARIHI = DateTime.Now, CD_EKL_KISI = Convert.ToInt16(isno), CD_GUNC_KISI = Convert.ToInt16(isno), DT_GUNC_TARIHI= DateTime.Now });
                }

            }
            catch(Exception e)
            {

            }
            return Json(result);
        }



    }
}