namespace PiDev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.claims", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.claims", "type", c => c.Int(nullable: false));
        }
    }
}
