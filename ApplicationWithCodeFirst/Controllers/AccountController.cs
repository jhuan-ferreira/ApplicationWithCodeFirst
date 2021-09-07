using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ApplicationWithCodeFirst.Models;

namespace ApplicationWithCodeFirst.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Usuarios());
        }


        [HttpPost]
        public ActionResult Login(Usuarios login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (BlogContext db = new BlogContext())
                {
                    var vLogin = db.Usuarios.Where(p => p.Email.Equals(login.Email)).FirstOrDefault();
                    /*Verificar se a variavel vLogin está vazia.
                    Isso pode ocorrer caso o usuário não existe.
              Caso não exista ele vai cair na condição else.*/

                    if (Repositorios.RepositorioUsuarios.VerificaSeOUsuarioEstaLogado() != null)
                    {
                        int a = 2;
                    }

                    if (vLogin != null)
                    {
                        /*Código abaixo verifica se o usuário que retornou na variavel tem está
                          ativo. Caso não esteja cai direto no else*/
                        if (Equals(vLogin.Ativo, "Sim"))
                        {
                            /*Código abaixo verifica se a senha digitada no site é igual a
                            senha que está sendo retornada
                             do banco. Caso não cai direto no else*/
                            if (Equals(vLogin.Senha, login.Senha))
                            {
                                //FormsAuthentication.SetAuthCookie(vLogin.Email, true);
                                //if (Url.IsLocalUrl(returnUrl)
                                //&& returnUrl.Length > 1
                                //&& returnUrl.StartsWith("/")
                                //&& !returnUrl.StartsWith("//")
                                //&& returnUrl.StartsWith("/\\"))
                                Repositorios.RepositorioCookies.RegistraCookieAutenticacao(vLogin.UsuarioID);
                                {
                                    return Redirect(returnUrl);
                                }
                                /*código abaixo cria uma session para armazenar o nome do usuário*/
                                Session["Nome"] = vLogin.Nome;
                                /*retorna para a tela inicial do Home*/
                                return RedirectToAction("Index", "Home");
                            }
                            /*Else responsável da validação da senha*/
                            else
                            {
                                /*Escreve na tela a mensagem de erro informada*/
                                ModelState.AddModelError("", "Senha informada Inválida!!!");
                                /*Retorna a tela de login*/
                                return View(new Usuarios());
                            }
                        }
                        /*Else responsável por verificar se o usuário está ativo*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!!!");
                            /*Retorna a tela de login*/
                            return View(new Usuarios());
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "E-mail informado inválido!!!");
                        /*Retorna a tela de login*/
                        return View(new Usuarios());
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login
            com as mensagem dos campos*/
            return View(login);
        }
    }
}