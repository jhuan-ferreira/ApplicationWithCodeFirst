using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApplicationWithCodeFirst.Models
{
    public class BlogContext : DbContext
    {
        //public BlogContext(): base("name=BlogContext")
        //{
        //    Database.Connection.ConnectionString = @"Data Source=LAPTOP-FQGS5UF8\yanfe; Initial Catalog= curso_sql; Integrated Security=True;";
        //}

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<BannersPublicitarios> BannersPublicitarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}