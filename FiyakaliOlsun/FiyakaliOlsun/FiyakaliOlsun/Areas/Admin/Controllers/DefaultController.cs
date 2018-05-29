using FiyakaliOlsun.Areas.Admin.ViewModels;
using FiyakaliOlsun.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FiyakaliOlsun.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View(new DefaultIndex());
        }

        [HttpPost]
        public ActionResult Index(DefaultIndex form, string returnUrl)
        {
            var user = Database.Session.Query<Admin_Kullanici>().FirstOrDefault(u => u.KullaniciAdi == form.Username);


            if (user == null || user.Parola != form.Password)
            {
                ModelState.AddModelError("Username", "Username or password is invalid !");
            }

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            FormsAuthentication.SetAuthCookie(form.Username, true);

            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(DefaultKayit form)
        {
            if (Database.Session.Query<Admin_Kullanici>().Any(p => p.KullaniciAdi == form.Username))
            {
                ModelState.AddModelError("Kullanıcı Adı", "Bu kullanıcı adı kullanılıyor.");
            } //username control in database. 

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }

            var admin = new Admin_Kullanici() //create a new user object
            {
                KullaniciAdi = form.Username,
                email = form.Email,
                Parola = form.Password
            };

            Database.Session.Save(admin); //save admin object to database
            Database.Session.Flush();

            return RedirectToAction("Index");
        }

        public ActionResult Home()
        {
            var admin = Database.Session.Query<Admin_Kullanici>().ToList();
            return View(new DefaultHome { Kullanici = admin });
        }

        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<Admin_Kullanici>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new DefaultEdit()
            {
                Username = user.KullaniciAdi,
                Email = user.email,
            }
            );
        }

        [HttpPost]
        public ActionResult Edit(int id, DefaultEdit form)
        {
            var user = Database.Session.Load<Admin_Kullanici>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            if (Database.Session.Query<Admin_Kullanici>().Any(p => p.KullaniciAdi == form.Username && p.Id != id))
            {
                ModelState.AddModelError("Username", "Username must be unique");
            } //username control in database. 

            if (!ModelState.IsValid) //form validation control
            {
                return View(form);
            }

            user.KullaniciAdi = form.Username;
            user.email = form.Email;

            Database.Session.Update(user); //save user object to database

            return RedirectToAction("Home");
        }

        public ActionResult ResetPassword(int id)
        {
            var user = Database.Session.Load<Admin_Kullanici>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new DefaultResetPassword()
            {
                Username = user.KullaniciAdi
            });
        }
        [HttpPost]
        public ActionResult ResetPassword(int id, DefaultResetPassword form)
        {
            var user = Database.Session.Load<Admin_Kullanici>(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            user.Parola = form.Password;
            Database.Session.Update(user); //save user object to database

            return RedirectToAction("Home");
        }
    }
}