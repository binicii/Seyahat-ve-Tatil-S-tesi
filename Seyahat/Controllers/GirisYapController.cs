﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Seyahat.Models.Siniflar;

namespace Seyahat.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();
        // GET: GirisYap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)  /* iki tane logın yaptık bırı post oldu yanı bır ıslem gerceklestıgı zaman . aynı ısımde 2 logın varsa bırı parametre alır.*/
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();  /*şartımı saglamıyorsa yenıden eynı sayfaya gonder*/ 
            }

            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");

        }
             
            
    }
}