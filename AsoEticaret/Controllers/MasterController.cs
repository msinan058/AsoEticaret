using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsoEticaret.Controllers
{
    public class MasterController : Controller
    {
        AsoEticaret.Models.AsoEntities db = new AsoEticaret.Models.AsoEntities();
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHeader()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string cookieValue = System.Web.HttpContext.Current.User.Identity.Name;
                ViewBag.AdSoyad = cookieValue.Split(';')[2];
            }
            else
                ViewBag.AdSoyad = "Hello.";
            // Sadece Ana Kategoriler ve Aktif Olanlar
            var data = db.Kategori.Where(w => w.UstId == null && w.Aktif == true).ToList();
            return PartialView(data);
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }
    }
}