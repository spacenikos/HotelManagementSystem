namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Amenities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmenitiesPerRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmenitiesPackage = c.String(maxLength: 50),
                        Tv = c.Boolean(nullable: false),
                        AirCondition = c.Boolean(nullable: false),
                        Sauna = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "AmenitiesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "AmenitiesId");
            AddForeignKey("dbo.Rooms", "AmenitiesId", "dbo.AmenitiesPerRooms", "Id");
            DropColumn("dbo.Rooms", "Tv");
            DropColumn("dbo.Rooms", "AirCondition");
            DropColumn("dbo.Rooms", "Sauna");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Sauna", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "AirCondition", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "Tv", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Rooms", "AmenitiesId", "dbo.AmenitiesPerRooms");
            DropIndex("dbo.Rooms", new[] { "AmenitiesId" });
            DropColumn("dbo.Rooms", "AmenitiesId");
            DropTable("dbo.AmenitiesPerRooms");
        }
    }
}
