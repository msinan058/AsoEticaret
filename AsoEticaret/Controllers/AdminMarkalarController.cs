using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsoEticaret.Controllers
{
    public class AdminMarkalarController : Controller
    {
        AsoEticaret.Models.AsoEntities db = new AsoEticaret.Models.AsoEntities();
        // GET: AdminMarkalar
        public ActionResult Index(AsoEticaret.Models.Markalar data)
        {
            return View(data);
        }
        [HttpPost]
        public ActionResult MarkaKaydet(AsoEticaret.Models.Markalar data)
        {
            if (data.ID == 0)
            {
                db.Markalar.Add(data);
            }
            else if (data.ID > 0)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult MarkaSil(int DeleteID)
        {
            var data = db.Markalar.Find(DeleteID);
            db.Markalar.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkaDuzenleme(int ID)
        {
            var model = db.Markalar.Find(ID);
            return View("Index", model);
            //return RedirectToAction("Index", model);
        }
    }
}