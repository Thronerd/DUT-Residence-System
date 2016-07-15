namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "AllocatedTimes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "AllocatedTimes");
            DropColumn("dbo.Rooms", "Quantity");
        }
    }
}
