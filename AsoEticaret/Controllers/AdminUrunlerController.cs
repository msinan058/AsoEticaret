using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsoEticaret.Controllers
{
    [Authorize]
    public class AdminUrunlerController : Controller
    {
        AsoEticaret.Models.AsoEntities db = new AsoEticaret.Models.AsoEntities();
        // GET: AdminKategoriler
        public ActionResult Index()
        {
            var data = db.Urunler.OrderBy(o => o.KategoriID).ThenBy(o => o.MarkaID).ToList();
            return View(data);
        }
        public ActionResult Duzenleme(AsoEticaret.Models.Urunler data)
        {
            if (data.ID == 0) ViewBag.Title = "Yeni Ürün Ekle";
            else if (data.ID > 0) ViewBag.Title = "Ürün Düzenleme"; 
            return View(data);
        }
        [HttpPost]
        public ActionResult Kaydet(AsoEticaret.Models.Urunler data, HttpPostedFileBase[] Resim)
        {
            if (Resim != null)
            {
                foreach (HttpPostedFileBase f in Resim)
                {
                    if (f != null)
                    {
                        string path = Server.MapPath("/") + "assets/images/urun/";
                        System.IO.FileInfo ff = new System.IO.FileInfo(path + f.FileName);
                        f.SaveAs(ff.FullName);

                        if (data.ID == 0)
                        {
                            Models.UrunResim uresim = new Models.UrunResim();
                            uresim.ResimAdi = f.FileName;
                            uresim.Sira = 1;
                            data.UrunResim.Add(uresim);
                        }
                        else if (data.ID > 0)
                        {
                            Models.UrunResim uresim = new Models.UrunResim();
                            uresim.UrunID = data.ID;
                            uresim.ResimAdi = f.FileName;
                            uresim.Sira = 1;
                            db.UrunResim.Add(uresim);
                        }
                    }
                }
            }

            if (data.ID == 0)
            {
                db.Urunler.Add(data);
            }
            else if (data.ID > 0)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UrunSil(int DeleteID)
        {
            var data = db.Urunler.Find(DeleteID);
            db.Urunler.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunDuzenleme(int ID)
        {
            var model = db.Urunler.Find(ID);
            ViewBag.Title = "Ürün Düzenleme";
            return View("Duzenleme", model);
        }
    }
}