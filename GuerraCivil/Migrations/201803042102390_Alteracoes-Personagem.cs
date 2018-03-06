namespace GuerraCivil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesPersonagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personagems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPersonagem = c.Int(nullable: false),
                        Nome = c.String(),
                        QuantQuadrinhos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personagems");
        }
    }
}
