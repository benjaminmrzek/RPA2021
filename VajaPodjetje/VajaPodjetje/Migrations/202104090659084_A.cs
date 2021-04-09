namespace VajaPodjetje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vrednost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumIzdaje = c.DateTime(nullable: false),
                        KupecId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kupecs", t => t.KupecId, cascadeDelete: true)
                .Index(t => t.KupecId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Racuns", "KupecId", "dbo.Kupecs");
            DropIndex("dbo.Racuns", new[] { "KupecId" });
            DropTable("dbo.Racuns");
        }
    }
}
