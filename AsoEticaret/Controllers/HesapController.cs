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
        AsoEticaret.Models.AsoEntities db = new AsoEticaret.Models.AsoEntities();
        // GET: Hesap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("UyeGiris");
        }
    }
}