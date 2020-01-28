namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reservations", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Reservations", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Rooms", "Reservation_Id", c => c.Int());
            CreateIndex("dbo.Rooms", "Reservation_Id");
            AddForeignKey("dbo.Rooms", "Reservation_Id", "dbo.Reservations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.Rooms", new[] { "Reservation_Id" });
            DropColumn("dbo.Rooms", "Reservation_Id");
            RenameIndex(table: "dbo.Reservations", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Reservations", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
