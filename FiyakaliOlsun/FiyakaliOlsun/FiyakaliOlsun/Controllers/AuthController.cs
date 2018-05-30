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

            [HttpPost]
            public ActionResult Index(AuthIndex form, string returnUrl)
            {
                var user = Database.Session.Query<Musteri>().FirstOrDefault(u => u.KullaniciAdi == form.Username);


                if (user == null || user.Parola != form.Password)
                {
                    ModelState.AddModelError("Username", "Username or password is invalid !");
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
                    return RedirectToRoute("Home");
                }
            }

            public ActionResult Cikis()
            {
                Session["Musteri"] = null;
                return RedirectToRoute("Home");
            }

            public ActionResult Kayit()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Kayit(AuthKayit form)
            {
                if (Database.Session.Query<Musteri>().Any(p => p.KullaniciAdi == form.Username))
                {
                    ModelState.AddModelError("Kullanıcı Adı", "Bu kullanıcı adı kullanılıyor.");
                } //username control in database. 

                if (!ModelState.IsValid) //form validation control
                {
                    return View(form);
                }

                var user = new Musteri() //create a new user object
                {
                    AdSoyad = form.AdSoyad,
                    email = form.Email,
                    Tel = form.Tel,
                    Adres = form.Adres,
                    DogumTarihi = form.DogumTarihi,
                    KullaniciAdi = form.Username,
                    Parola = form.Password
                };

                Database.Session.Save(user); //save admin object to database
                Database.Session.Flush();

                return RedirectToRoute("Kayit");
            }
        }
    }