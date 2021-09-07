using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationWithCodeFirst.Models
{
    [MetadataType (typeof(CategoriasMetadados))]
    public partial class Categorias
    {

    }
    public class CategoriasMetadados
    {
        [Required(ErrorMessage ="É obrigatório informar a descrição da categoria")]
        [StringLength (30, ErrorMessage ="A descrição deve conter no máximo 30 caracteres")]
        
        public string Descricao { get; set; }
    }
}