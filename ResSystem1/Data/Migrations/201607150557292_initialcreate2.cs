namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Residences", "Booking_bookingId", "dbo.Bookings");
            DropIndex("dbo.Residences", new[] { "Booking_bookingId" });
            AddColumn("dbo.OtherUsers", "Role", c => c.String());
            AlterColumn("dbo.Bookings", "residenceCode", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bookings", "residenceCode");
            AddForeignKey("dbo.Bookings", "residenceCode", "dbo.Residences", "residenceCode");
            DropColumn("dbo.Residences", "Booking_bookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Residences", "Booking_bookingId", c => c.Int());
            DropForeignKey("dbo.Bookings", "residenceCode", "dbo.Residences");
            DropIndex("dbo.Bookings", new[] { "residenceCode" });
            AlterColumn("dbo.Bookings", "residenceCode", c => c.String());
            DropColumn("dbo.OtherUsers", "Role");
            CreateIndex("dbo.Residences", "Booking_bookingId");
            AddForeignKey("dbo.Residences", "Booking_bookingId", "dbo.Bookings", "bookingId");
        }
    }
}
