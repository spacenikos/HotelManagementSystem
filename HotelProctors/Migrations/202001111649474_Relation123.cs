namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.Rooms", new[] { "Reservation_Id" });
            AddColumn("dbo.Reservations", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "RoomId");
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "Reservation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Reservation_Id", c => c.Int());
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropColumn("dbo.Reservations", "RoomId");
            CreateIndex("dbo.Rooms", "Reservation_Id");
            AddForeignKey("dbo.Rooms", "Reservation_Id", "dbo.Reservations", "Id");
        }
    }
}
