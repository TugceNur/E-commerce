using FiyakaliOlsun.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FiyakaliOlsun.Controllers
{

    public class LoginController : Controller
    {
        public ActionResult New()
        {
            return View(new LoginController() { });
        }

        [HttpPost]
        public ActionResult New(Musteri formdata)
        {

            if (Database.Session.Query<Musteri>().Any(p => p.KullaniciAdi == formdata.KullaniciAdi))
            {
                ModelState.AddModelError("Username", "Username  must be unique");
            }

            if (!ModelState.IsValid)
            {
                return View(formdata);
            }

            var user = new Musteri()
            {
                KullaniciAdi = formdata.KullaniciAdi,
                Parola = formdata.Parola

            };

            Database.Session.Save(user);

            return RedirectToRoute("Home");
        }

        [HttpGet]
        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(Musteri formdata)
        {
            if (Database.Session.Query<Musteri>().Any(p => p.KullaniciAdi == formdata.KullaniciAdi))
            {
                ModelState.AddModelError("Username", "Bu kullanıcı mevcut!");
            }

            if (!ModelState.IsValid)
            {
                return View(formdata);
            }

            var user = new Musteri()
            {
                KullaniciAdi = formdata.KullaniciAdi,
                Parola = formdata.Parola,
                email = formdata.email,
                Tel = formdata.Tel,
                Adres = formdata.Adres,
                AdSoyad = formdata.AdSoyad,
                DogumTarihi = formdata.DogumTarihi,
                SepetId = new Sepet { Id = 1 }
            };

            Database.Session.Save(user);
            return View();
        }

    }
}