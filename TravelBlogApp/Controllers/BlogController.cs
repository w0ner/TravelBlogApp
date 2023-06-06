using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogApp.Models.Sınıflar;

namespace TravelBlogApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context context = new Context();
        BlogYorumVM yorumVM = new BlogYorumVM();

        public ActionResult Index()
        {
            //var bloglar = context.Blogs.ToList();
            yorumVM.Deger1 = context.Blogs.ToList();
            yorumVM.Deger3 = context.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return View(yorumVM);
        }


        public ActionResult BlogDetay(int id)
        {
            //var blogbul = context.Blogs.Where(x => x.ID == id).ToList();

            yorumVM.Deger1=context.Blogs.Where(x=>x.ID==id).ToList();
            yorumVM.Deger2=context.Yorumlars.Where(x=>x.Blogid==id).ToList();
            return View(yorumVM);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            context.Yorumlars.Add(y);
            context.SaveChanges();
            return PartialView();
        }
    }
}