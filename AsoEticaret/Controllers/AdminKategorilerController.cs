using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsoEticaret.Controllers
{
    public class AdminKategorilerController : Controller
    {
        AsoEticaret.Models.AsoEntities db = new AsoEticaret.Models.AsoEntities();
        // GET: AdminKategoriler
        public ActionResult Index(AsoEticaret.Models.Kategori data, int? UstKatID)
        {
            if (UstKatID != null)
                ViewBag.UstKatID = data.UstId = UstKatID.Value;
            else
                ViewBag.UstKatID = null;

            return View(data);
        }
        [HttpPost]
        public ActionResult KategoriKaydet(AsoEticaret.Models.Kategori data)
        {
            if (data.Id == 0)
            {
                db.Kategori.Add(data);
            }
            else if (data.Id > 0)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { UstKatID = data.UstId });
        }
        [HttpPost]
        public ActionResult KategoriSil(int DeleteID)
        {
            var data = db.Kategori.Find(DeleteID);
            int? ustID = data.UstId;
            db.Kategori.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index", new { UstKatID = ustID });
        }
        public ActionResult KategoriDuzenleme(int ID)
        {
            var model = db.Kategori.Find(ID);
            if (model.UstId != null)
                ViewBag.UstKatID = model.UstId;
            else
                ViewBag.UstKatID = null;
            return View("Index", model);
            //return RedirectToAction("Index", data);
        }
        [Route("AdminKategoriler/AltKategoriGetir/{UstKatID}")]
        public ActionResult AltKategoriGetir(int? UstKatID)
        {
            var model = new AsoEticaret.Models.Kategori();
            model.UstId = UstKatID;
            if (UstKatID != null)
                ViewBag.UstKatID = model.UstId = UstKatID.Value;
            else
                ViewBag.UstKatID = null;

            List<Models.Kategori> lstKategori = new List<Models.Kategori>();
            UstKategorileriDoldur(db, UstKatID, ref lstKategori);

            ViewBag.lstKategori = lstKategori;
            return View("Index", model);
            //return RedirectToAction("Index", new { UstKatID = UstKatID });
        }
        public static void UstKategorileriDoldur(AsoEticaret.Models.AsoEntities db, int? UstKatID, ref List<Models.Kategori> lstKategori)
        {
            var data = db.Kategori.Find(UstKatID.Value);
            if (!lstKategori.Contains(data))
            {
                lstKategori.Add(data);
            }
            if (data.UstId != null)
            {
                UstKategorileriDoldur(db, data.UstId, ref lstKategori);
            }
        }
    }
}