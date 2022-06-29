using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnketProjesi.Models.Entity;

namespace AnketProjesi.Controllers
{
    public class AnketOlusturController : Controller
    {
        AnketProjesiDBEntities db = new AnketProjesiDBEntities();
        // GET: AnketOlustur
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ANKT_Anketler p1,ANKT_Sorular p2,ANKT_Secenekler p3)
        {
            db.ANKT_Anketler.Add(p1);
            db.ANKT_Sorular.Add(p2);
            db.ANKT_Secenekler.Add(p3);
            db.SaveChanges();
            return View(p1);
        }
    }
}