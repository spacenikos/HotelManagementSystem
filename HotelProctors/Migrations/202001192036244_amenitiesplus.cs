namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amenitiesplus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AmenitiesPerRooms", "AlarmClock", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "BathAmenities", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "CentralHeating", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "CoffeeFacilities", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "VoiceMail", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "Hairdryer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "MiniBar", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "MovieChannels", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "Slippers", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "WakeUpCall", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "FreeWiFi", c => c.Boolean(nullable: false));
            AddColumn("dbo.AmenitiesPerRooms", "Closet", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AmenitiesPerRooms", "Closet");
            DropColumn("dbo.AmenitiesPerRooms", "FreeWiFi");
            DropColumn("dbo.AmenitiesPerRooms", "WakeUpCall");
            DropColumn("dbo.AmenitiesPerRooms", "Slippers");
            DropColumn("dbo.AmenitiesPerRooms", "MovieChannels");
            DropColumn("dbo.AmenitiesPerRooms", "MiniBar");
            DropColumn("dbo.AmenitiesPerRooms", "Hairdryer");
            DropColumn("dbo.AmenitiesPerRooms", "VoiceMail");
            DropColumn("dbo.AmenitiesPerRooms", "CoffeeFacilities");
            DropColumn("dbo.AmenitiesPerRooms", "CentralHeating");
            DropColumn("dbo.AmenitiesPerRooms", "BathAmenities");
            DropColumn("dbo.AmenitiesPerRooms", "AlarmClock");
        }
    }
}
