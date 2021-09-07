using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ApplicationWithCodeFirst.Models;

namespace ApplicationWithCodeFirst.Repositorios
{
    public class RepositorioUsuarios
    {
        public static bool AutenticaUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            try
            {
                using (Models.BlogContext db = new Models.BlogContext())
                {
                    var QueryAutenticaUsuarios = db.Usuarios.Where(x => x.Login == Login && x.Senha == Senha).SingleOrDefault();
                    if (QueryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(QueryAutenticaUsuarios.UsuarioID);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


        public static Usuarios RecuperaUsuarioPorID(long IDUsuario)
        {
            try
            {
                using (BlogContext db = new BlogContext())
                {
                    var usuario = db.Usuarios.Where(u => u.UsuarioID == IDUsuario).SingleOrDefault();
                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Usuarios VerificaSeOUsuarioEstaLogado()
        {
            var usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (usuario == null)
            {
                return null;
            }
            else
            {
                long iDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(usuario.Values["IDUsuario"]));

                var usuarioRetornado = RecuperaUsuarioPorID(iDUsuario);
                return usuarioRetornado;

            }
        }


    }
}
