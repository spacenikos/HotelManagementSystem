namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            DropColumn("dbo.Rooms", "ReservationId");
            DropColumn("dbo.Rooms", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "UserId", c => c.String());
            AddColumn("dbo.Rooms", "ReservationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "ReservationId");
            AddForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
        }
    }
}
