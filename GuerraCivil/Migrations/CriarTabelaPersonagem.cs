using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GuerraCivil.Migrations
{
    public class CriarTabelaPersonagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personagems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
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