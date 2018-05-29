using FiyakaliOlsun.Areas.Admin.ViewModels;
using FiyakaliOlsun.Infrastructer;
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
    [SelectedTabAttribute("Urunler")]
    public class PostController : Controller
    {
        // GET: Admin/Post
        private const int PostPerPage = 1;
        public ActionResult Index(int page = 1)
        {
            int totalPostCount = Database.Session.Query<Urunler>().Count();

            var currentPostPage = Database.Session.Query<Urunler>()
                .Skip((page - 1) * PostPerPage)
                .Take(PostPerPage)
                .ToList();

            return View(new PostIndex() { Posts = new PagedData<Urunler>(currentPostPage, totalPostCount, page, PostPerPage) });
        }

        public ActionResult New()
        {
            return View("Form", new PostForm() { IsNew = true });
        }

        public ActionResult Edit(int id)
        {
            var post = Database.Session.Load<Urunler>(id);
            if (post == null)
            {
                return HttpNotFound();
            }


            return View("Form", new PostForm() { IsNew = false, urunId = post.Id, urunAdi = post.UrunAdi, urunResim = post.UrunResim, Fiyat = post.Fiyat, Aciklama = post.Aciklama });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Form(PostForm form)
        {
            form.IsNew = form.urunId == null;

            if (!ModelState.IsValid)
                return View(form);

            Urunler post;

            if (form.IsNew)
            {
                post = new Urunler()
                {
                    UrunAdi = form.urunAdi,
                    UrunResim = form.urunResim,
                    Fiyat = form.Fiyat,
                    Aciklama = form.Aciklama
                };
            }
            else
            {
                post = Database.Session.Load<Urunler>(form.urunId);

                if (post == null)
                {
                    return HttpNotFound();
                }

                post.UrunAdi = form.urunAdi;
                post.UrunResim = form.urunResim;
                post.Fiyat = form.Fiyat;
                post.Aciklama = form.Aciklama;
            }

            Database.Session.SaveOrUpdate(post);

            Database.Session.Flush();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var post = Database.Session.Load<Urunler>(id);
            if (post == null)
                return HttpNotFound();

            Database.Session.Delete(post);
            return RedirectToAction("Index");
        }
    }
}