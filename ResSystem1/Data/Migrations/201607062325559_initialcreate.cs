namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        IdNo = c.String(),
                        contactNo = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        bookingId = c.Int(nullable: false, identity: true),
                        year = c.String(),
                        studentNo = c.String(maxLength: 128),
                        date = c.DateTime(nullable: false),
                        roomId = c.String(),
                        blockCode = c.String(),
                        residenceCode = c.String(),
                    })
                .PrimaryKey(t => t.bookingId)
                .ForeignKey("dbo.Students", t => t.studentNo)
                .Index(t => t.studentNo);
            
            CreateTable(
                "dbo.Residences",
                c => new
                    {
                        residenceCode = c.String(nullable: false, maxLength: 128),
                        ResName = c.String(),
                        address = c.String(),
                        campus = c.String(),
                        contactNo = c.String(),
                        noOfRooms = c.Int(nullable: false),
                        capacity = c.Int(nullable: false),
                        Booking_bookingId = c.Int(),
                    })
                .PrimaryKey(t => t.residenceCode)
                .ForeignKey("dbo.Bookings", t => t.Booking_bookingId)
                .Index(t => t.Booking_bookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        roomId = c.String(nullable: false, maxLength: 128),
                        beds = c.Int(nullable: false),
                        roomType = c.String(),
                        status = c.String(),
                        residenceCode = c.String(maxLength: 128),
                        Booking_bookingId = c.Int(),
                    })
                .PrimaryKey(t => t.roomId)
                .ForeignKey("dbo.Residences", t => t.residenceCode)
                .ForeignKey("dbo.Bookings", t => t.Booking_bookingId)
                .Index(t => t.residenceCode)
                .Index(t => t.Booking_bookingId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentNo = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        gender = c.String(),
                        DOB = c.String(),
                        emailAddress = c.String(),
                        contactNo = c.Int(nullable: false),
                        blockCode = c.String(),
                        yearOfStudy = c.String(),
                        course = c.String(),
                        physicalAddress = c.String(),
                        registrationYr = c.String(),
                        NoOfModules = c.Int(nullable: false),
                        funder = c.String(),
                        levelOfStudy = c.String(),
                        financialStatus = c.String(),
                        Student_studentNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.studentNo)
                .ForeignKey("dbo.Students", t => t.Student_studentNo)
                .Index(t => t.Student_studentNo);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        visitorId = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        timeIn = c.DateTime(nullable: false),
                        timeOut = c.DateTime(nullable: false),
                        studentNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.visitorId)
                .ForeignKey("dbo.Students", t => t.studentNo)
                .Index(t => t.studentNo);
            
            CreateTable(
                "dbo.Funders",
                c => new
                    {
                        funderId = c.Int(nullable: false, identity: true),
                        funderName = c.String(),
                    })
                .PrimaryKey(t => t.funderId);
            
            CreateTable(
                "dbo.OtherUsers",
                c => new
                    {
                        userId = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        gender = c.String(),
                        emailAddress = c.String(),
                        contactNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "studentNo", "dbo.Students");
            DropForeignKey("dbo.Visitors", "studentNo", "dbo.Students");
            DropForeignKey("dbo.Students", "Student_studentNo", "dbo.Students");
            DropForeignKey("dbo.Rooms", "Booking_bookingId", "dbo.Bookings");
            DropForeignKey("dbo.Residences", "Booking_bookingId", "dbo.Bookings");
            DropForeignKey("dbo.Rooms", "residenceCode", "dbo.Residences");
            DropIndex("dbo.Visitors", new[] { "studentNo" });
            DropIndex("dbo.Students", new[] { "Student_studentNo" });
            DropIndex("dbo.Rooms", new[] { "Booking_bookingId" });
            DropIndex("dbo.Rooms", new[] { "residenceCode" });
            DropIndex("dbo.Residences", new[] { "Booking_bookingId" });
            DropIndex("dbo.Bookings", new[] { "studentNo" });
            DropTable("dbo.OtherUsers");
            DropTable("dbo.Funders");
            DropTable("dbo.Visitors");
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
            DropTable("dbo.Residences");
            DropTable("dbo.Bookings");
            DropTable("dbo.Admins");
        }
    }
}
