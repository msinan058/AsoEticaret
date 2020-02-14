using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AsoEticaret.Controllers
{
    public partial class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult UyeGiris(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        public ActionResult Giris(string Email, string Sifre, string ReturnUrl)
        {
            Models.Uye uye = db.Uye.Where(w => w.Email == Email && w.Sifre == Sifre).FirstOrDefault();
            if (uye != null)
            {
                string cookieValue = uye.ID + ";" + uye.Email + ";" + uye.AdSoyad;
                FormsAuthentication.SetAuthCookie(cookieValue, false);
                if (ReturnUrl != "")
                    return Redirect(ReturnUrl);
                return Redirect("~/");
            }
            else
                return View("UyeGiris");
        }
    }
}