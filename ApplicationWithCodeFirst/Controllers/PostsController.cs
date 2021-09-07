using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationWithCodeFirst.Models;

namespace ApplicationWithCodeFirst.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts

        private BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            var post = db.Posts.Include("Categorias").ToList();
            return View(post);
        }

        public ActionResult Adicionar()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");

            return View();

        }

        [HttpPost]
        public ActionResult Adicionar(Posts posts)
        {

            if (ModelState.IsValid)
            {
                db.Posts.Add(posts);
                db.SaveChanges();
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");

            return RedirectToAction("Index", "Posts", "Index");

        }

        public ActionResult Editar(long id)
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");
            Posts posts = db.Posts.Find(id);


            return View(posts);

        }

        [HttpPost]
        public ActionResult Editar(Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Posts", "Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");
            return View(posts);
        }


    }
}