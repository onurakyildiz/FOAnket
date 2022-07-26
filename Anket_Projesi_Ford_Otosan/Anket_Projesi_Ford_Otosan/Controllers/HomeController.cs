using Anket_Projesi_Ford_Otosan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Anket_Projesi_Ford_Otosan.Controllers
{
    public class HomeController : Controller
    {

        ANKET_DBEntities db = new ANKET_DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ANK_CALISANLAR au)
        {
            try
            {
                string user = au.CH_KUL_ADI;
                string pass = au.CH_SIFRE;

                using (db)
                {
                    string status;
                    var usr = (from e in db.ANK_CALISANLAR where e.CH_KUL_ADI == user && e.CH_SIFRE == pass select e).FirstOrDefault();

                    if (usr != null)
                    {
                        Session["CH_KUL_ADI"] = usr.CH_KUL_ADI.ToString();
                        Session["SW_YETKI"] = usr.SW_YETKI;
                        var ıd=Session["SQ_IS_NO"] = usr.SQ_IS_NO;
                        //Kullanıcının İş Numarasını Gönderme
                        HttpCookie cookie = new HttpCookie("isno",""+ıd);
                        Response.Cookies.Add(cookie);

                        if (usr.SW_YETKI == true)
                        {
                            status = "1";
                        }
                        else
                        {
                            status = "2";
                        }

                    }
                    else
                    {
                        status = "3";
                    }
                    return new JsonResult { Data = new { status = status } };
                }
            }
            catch(Exception e)
            {

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Remove("CH_KUL_ADI");
            return RedirectToAction("Index", "Home");
        }
    }
}