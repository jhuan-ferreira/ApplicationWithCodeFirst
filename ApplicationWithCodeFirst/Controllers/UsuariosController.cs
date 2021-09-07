using System.Web.Mvc;
using ApplicationWithCodeFirst.Models;
using ApplicationWithCodeFirst.Repositorios;

namespace ApplicationWithCodeFirst.Controllers
{
    public class UsuariosController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: Usuarios
        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuarios.AutenticaUsuario(Login, Senha))
            {
                return Json(new { OK = true, Mensagem = "Usuário autenticado. Redirecionando..." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false, Mensagem = "Usuário não encontrando. Tente novamente." }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home", "Index");
        }

    }
}