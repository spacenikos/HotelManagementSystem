namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RESERVATION1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "RoomId", c => c.Int(nullable: true));
            AddColumn("dbo.Rooms", "ReservationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "ReservationId");
            DropColumn("dbo.Reservations", "RoomId");
        }
    }
}
