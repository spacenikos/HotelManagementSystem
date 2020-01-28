namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Reservation_Id", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Reservation_Id");
        }
    }
}
