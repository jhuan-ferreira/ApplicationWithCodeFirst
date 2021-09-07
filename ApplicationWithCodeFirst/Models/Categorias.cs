using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationWithCodeFirst.Models
{
    public partial class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}