using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationWithCodeFirst.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public string Nome { get; set; }
        public string Ativo { get; set; }
    }
}