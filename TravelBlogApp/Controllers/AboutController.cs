using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlogApp.Models.Sınıflar;

namespace TravelBlogApp.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context context = new Context();

        public ActionResult Index()
        {
            var degerler = context.Hakkımızdas.ToList();
            return View(degerler);
        }
    }
}