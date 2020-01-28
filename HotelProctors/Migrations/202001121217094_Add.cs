namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "Reservation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Reservation_Id", c => c.Int(nullable: false));
        }
    }
}
