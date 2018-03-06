using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;


namespace GuerraCivil.Migrations 
{
    public class AddIdPersonagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personagems", "IdPersonagem", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Personagems", "IdPersonagem");
        }
    }
}