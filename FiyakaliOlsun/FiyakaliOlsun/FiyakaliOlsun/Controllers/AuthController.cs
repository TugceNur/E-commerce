using FiyakaliOlsun.Infrastructer;
using FiyakaliOlsun.Models;
using FiyakaliOlsun.ViewModels;
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
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View(new AuthIndex());
        }
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AuthIndex form, string returnUrl)
        {
            var user = Database.Session.Query<Musteri>().FirstOrDefault(u => u.KullaniciAdi == form.Username);


            if (user == null || user.Parola != form.Password)
            {
                ModelState.AddModelError("Username", "Kullanıcı adı veya şifre geçersiz!");
            }

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            Session["Musteri"] = form.Username;

            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                Models.LoginState._LoginState = true;
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult Cikis()
        {
            Session["Musteri"] = null;
            Models.LoginState._LoginState = false;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Kayit()
        {
            Models.LoginState._RegSuccess = false;
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(AuthKayit form)
        {
            if (Database.Session.Query<Musteri>().Any(p => p.KullaniciAdi == form.Username))
            {
                ModelState.AddModelError("Kullanıcı Adı", "Bu kullanıcı adı kullanılıyor.");
            } //username control in database. 

            if (!ModelState.IsValid) //formu doğruluyor
            {
                return View(form);
            }

            var user = new Musteri() //musteriden user adında kullanıcı olusturuldu.
            {
                AdSoyad = form.AdSoyad,
                email = form.Email,
                Tel = form.Tel,
                Adres = form.Adres,
                DogumTarihi = form.DogumTarihi,
                KullaniciAdi = form.Username,
                Parola = form.Password
            };

            Database.Session.Save(user); //kullanıcı kaydedildi.
            Database.Session.Flush();
            Models.LoginState._RegSuccess = true;
            return RedirectToRoute("Index");
        }
    }
}