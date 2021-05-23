using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seyahat.Models.Siniflar;
namespace Seyahat.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]  /* WEBCONFİG KISMINA EKLENEN YER . OTURUM ACMAYAN KISI ADMIN INDEX SAYFASINA YONLENDIRILMEYECEK , GİRİS YAP KISMINA GIDILCEK*/
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]                 /*sayfa yuklenırken hıcbırsey yapma sayfanın bos halını bana dondur        */
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]                  /*yapılan işlemlerı dondur */ 
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");    /*benı ındex aksıyonuna yonlendır dedım  */
        }
        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bloglar = c.Blogs.Find(id);
            return View("BlogGetir", bloglar);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);    /* Blog ıcındekı Id degerıne karsılık gelen Blogu Yenı degısken(b)ın ıcıne Guncelle*/
            blg.Aciklama = b.Aciklama;      /* Varsayılan bılgının yerıne yenısını yaz yanı blg yerıne b olarak guncellle*/
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");  /* bu ıslemlerı yapıp guncelle dedıkten sonra benı Index sayfasına yonlendır */
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");       /*YorumListesi sayfasına yonlendırdık, yanı sildikten sonra aynı sayfada kalıyor*/
        }
        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View("YorumGetir", yrm);
        }
        public ActionResult YorumGuncelle(Yorumlar y)     /*YorumListesi Kısmında Guncelleme yaparken kullandım*/
        {
            var yorum = c.Yorumlars.Find(y.ID);           /* Yorumlar ıcındekı Id degerıne karsılık gelen Blogu Yenı degısken(y)ın ıcıne Guncelle*/
            yorum.KullaniciAdi = y.KullaniciAdi;          /* Varsayılan bılgının yerıne yenısını yaz yanı yorun yerıne y olarak guncellle*/
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");            /* bu ıslemlerı yapıp guncelle dedıkten sonra benı Index sayfasına yonlendır */
        }

    }
}