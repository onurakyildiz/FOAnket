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
                        var ank = (from e in db.ANK_ANKETLER  select e).FirstOrDefault();
                        return View(ank);
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

    }
}