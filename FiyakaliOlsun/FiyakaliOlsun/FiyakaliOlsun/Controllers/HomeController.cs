using FiyakaliOlsun.Models;
using FiyakaliOlsun.ViewModels;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FiyakaliOlsun.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult Canta()
        {
            return View();
        }
        public ActionResult Ayakkabi()
        {
            return View();
        }
        public ActionResult Goruntule()
        {
            return View();
        }
        public ActionResult Index()
        {
            var urun = Database.Session.Query<Urunler>().ToList();

            return View(new HomeIndex()
            {
                urunler = urun
            });
        }
    }
}