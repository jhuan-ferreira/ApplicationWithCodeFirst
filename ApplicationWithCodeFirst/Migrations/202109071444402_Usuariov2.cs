namespace ApplicationWithCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuariov2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Email", c => c.String());
            AddColumn("dbo.Usuarios", "Perfil", c => c.String());
            AddColumn("dbo.Usuarios", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Nome");
            DropColumn("dbo.Usuarios", "Perfil");
            DropColumn("dbo.Usuarios", "Email");
        }
    }
}
