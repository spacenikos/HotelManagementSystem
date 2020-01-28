namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Telephone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Telephone", c => c.String());
            DropColumn("dbo.Reservations", "ReservationNumber");
        }
    }
}
