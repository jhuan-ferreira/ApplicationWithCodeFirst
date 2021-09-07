using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationWithCodeFirst.Models;

namespace ApplicationWithCodeFirst.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        private BlogContext db = new BlogContext();
        public ActionResult Index()
        {

            ViewBag.Banners =  db.BannersPublicitarios. OrderByDescending(b => b.BannerID).Take(2);
            var categorias = db.Categorias.ToList();
            return View(categorias);

        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categorias, "CategoriaID", "Nome");
            return View(categorias);

        }

        public ActionResult Editar(long id)
        {
            Categorias categorias = db.Categorias.Find(id);
            return View(categorias);
        }

        [HttpPost]
        public ActionResult Editar(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Categorias", "Posts");
            }

            return View(categorias);
        }

        public string Delete(long id)
        {
            try
            {
                Categorias categorias = db.Categorias.Find(id);
                db.Categorias.Remove(categorias);
                db.SaveChanges();
                return Boolean.TrueString;
            }

            catch
            {
                return Boolean.FalseString;
            }

        }
    
    }

}