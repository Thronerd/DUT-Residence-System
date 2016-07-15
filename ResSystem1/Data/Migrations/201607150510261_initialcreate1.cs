namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Booking_bookingId", "dbo.Bookings");
            DropForeignKey("dbo.Students", "Student_studentNo", "dbo.Students");
            DropIndex("dbo.Rooms", new[] { "Booking_bookingId" });
            DropIndex("dbo.Students", new[] { "Student_studentNo" });
            CreateTable(
                "dbo.Registractions",
                c => new
                    {
                        RegNum = c.Int(nullable: false, identity: true),
                        studentNo = c.String(maxLength: 128),
                        bookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegNum)
                .ForeignKey("dbo.Bookings", t => t.bookingId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.studentNo)
                .Index(t => t.studentNo)
                .Index(t => t.bookingId);
            
            AddColumn("dbo.Bookings", "RoomType", c => c.String());
            AddColumn("dbo.Bookings", "Bookingdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Residences", "ResName", c => c.String());
            AddColumn("dbo.Residences", "Gender", c => c.String());
            AddColumn("dbo.Residences", "noOfRoomsAvailable", c => c.Int(nullable: false));
            AddColumn("dbo.Residences", "RoomType", c => c.String());
            DropColumn("dbo.Bookings", "date");
            DropColumn("dbo.Bookings", "roomId");
            DropColumn("dbo.Residences", "building");
            DropColumn("dbo.Rooms", "Booking_bookingId");
            DropColumn("dbo.Students", "Student_studentNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Student_studentNo", c => c.String(maxLength: 128));
            AddColumn("dbo.Rooms", "Booking_bookingId", c => c.Int());
            AddColumn("dbo.Residences", "building", c => c.String());
            AddColumn("dbo.Bookings", "roomId", c => c.String());
            AddColumn("dbo.Bookings", "date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Registractions", "studentNo", "dbo.Students");
            DropForeignKey("dbo.Registractions", "bookingId", "dbo.Bookings");
            DropIndex("dbo.Registractions", new[] { "bookingId" });
            DropIndex("dbo.Registractions", new[] { "studentNo" });
            DropColumn("dbo.Residences", "RoomType");
            DropColumn("dbo.Residences", "noOfRoomsAvailable");
            DropColumn("dbo.Residences", "Gender");
            DropColumn("dbo.Residences", "ResName");
            DropColumn("dbo.Bookings", "Bookingdate");
            DropColumn("dbo.Bookings", "RoomType");
            DropTable("dbo.Registractions");
            CreateIndex("dbo.Students", "Student_studentNo");
            CreateIndex("dbo.Rooms", "Booking_bookingId");
            AddForeignKey("dbo.Students", "Student_studentNo", "dbo.Students", "studentNo");
            AddForeignKey("dbo.Rooms", "Booking_bookingId", "dbo.Bookings", "bookingId");
        }
    }
}
