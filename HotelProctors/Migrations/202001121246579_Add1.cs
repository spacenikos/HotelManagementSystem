namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
    }
}
