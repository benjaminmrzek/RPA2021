namespace VajaPodjetje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class B : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kupecs", "Kontakt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kupecs", "Kontakt", c => c.String());
        }
    }
}
