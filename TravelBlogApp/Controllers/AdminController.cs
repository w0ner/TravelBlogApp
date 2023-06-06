using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogApp.Models.Sınıflar;

namespace TravelBlogApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler=context.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b= context.Blogs.Find(id);
            context.Blogs.Remove(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var blog = context.Blogs.Find(id);
            return View("BlogGetir", blog);
        }

        public ActionResult BlogGuncelle(Blog blog)
        {
            var blg = context.Blogs.Find(blog.ID);
            blg.Aciklama= blog.Aciklama;
            blg.Baslik= blog.Baslik;
            blg.BlogImage= blog.BlogImage;
            blg.Tarih= blog.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(b);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = context.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}