namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "Id", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "Id" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.Rooms", new[] { "UserId" });
            RenameColumn(table: "dbo.Reservations", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Rooms", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Reservations", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rooms", "UserId", c => c.String());
            CreateIndex("dbo.Reservations", "ApplicationUser_Id");
            CreateIndex("dbo.Rooms", "ReservationId");
            CreateIndex("dbo.Rooms", "ApplicationUser_Id");
            AddForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Rooms", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
            DropColumn("dbo.Reservations", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "RoomId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Rooms", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Rooms", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Reservations", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Rooms", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Reservations", name: "ApplicationUser_Id", newName: "UserId");
            CreateIndex("dbo.Rooms", "UserId");
            CreateIndex("dbo.Reservations", "UserId");
            CreateIndex("dbo.Reservations", "Id");
            AddForeignKey("dbo.Reservations", "Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Reservations", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
