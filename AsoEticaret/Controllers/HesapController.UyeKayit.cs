using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsoEticaret.Controllers
{
    public partial class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult UyeKayit()
        {
            return View();
        }
        public ActionResult Kaydet(string AdSoyad, string Email, string Telefon, string TC, string Sifre)
        {
            if (db.Uye.Any(w => w.Email == Email) == false)
            {
                Models.Uye uye = new Models.Uye();
                uye.AdSoyad = AdSoyad;
                uye.Email = Email;
                uye.Telefon = Telefon;
                uye.TC = TC;
                uye.Sifre = Sifre;
                db.Uye.Add(uye);
                db.SaveChanges();
            }

            return View("UyeGiris");
        }
    }
}