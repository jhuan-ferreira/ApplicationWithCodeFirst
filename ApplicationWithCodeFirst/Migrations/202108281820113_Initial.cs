namespace ApplicationWithCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BannersPublicitarios",
                c => new
                    {
                        BannerID = c.Int(nullable: false, identity: true),
                        TituloCampanha = c.String(),
                        BannerCampanha = c.String(),
                        LinkCampanha = c.String(),
                    })
                .PrimaryKey(t => t.BannerID);
            
            AlterColumn("dbo.Categorias", "Descricao", c => c.String(nullable: true, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categorias", "Descricao", c => c.String());
            DropTable("dbo.BannersPublicitarios");
        }
    }
}
