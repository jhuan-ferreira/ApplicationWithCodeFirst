using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationWithCodeFirst.Models
{
    public class BannersPublicitarios
    {
        [Key]
        public int BannerID { get; set; }
        public string TituloCampanha { get; set; }
        public string BannerCampanha { get; set; }
        public string LinkCampanha { get; set; }
    }
}