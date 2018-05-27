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
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            // gelen kullanıcı adi ve  şifreeyi veritabanından kontrol edilecek
            FormsAuthentication.SetAuthCookie(name, true);
            return RedirectToRoute("Home");
        }
        public ActionResult UyeOl()
        {
           return View();
        }

    }
}