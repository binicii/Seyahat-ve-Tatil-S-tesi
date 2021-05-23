using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seyahat.Models.Siniflar;

namespace Seyahat.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hakkımızdas.ToList(); //HAKKIMIZDA TABLOSUNUN VERILERINI KULLNACAK
            return View(degerler);
        }
    }
}