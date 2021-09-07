namespace ApplicationWithCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuariosV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Ativo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Ativo");
        }
    }
}
