using FiyakaliOlsun.Areas.Admin.ViewModels;
using FiyakaliOlsun.Infrastructure;
using FiyakaliOlsun.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiyakaliOlsun.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        private const int PostPerPage = 10;
        public ActionResult Index(int page = 1)
        {
            int totalPostCount = Database.Session.Query<Urunler>().Count();

            var currentPostPage = Database.Session.Query<Urunler>()
                .Skip((page - 1) * PostPerPage)
                .Take(PostPerPage)
                .ToList();

            return View(new PostIndex() { Posts = new PagedData<Urunler>(currentPostPage, totalPostCount, page, PostPerPage) });
        }
    }
}