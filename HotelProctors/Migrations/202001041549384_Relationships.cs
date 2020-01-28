namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Rooms", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Reservations", "Id");
            CreateIndex("dbo.Reservations", "UserId");
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Reservations", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "Id", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.Reservations", new[] { "Id" });
            DropColumn("dbo.Rooms", "UserId");
            DropColumn("dbo.Reservations", "UserId");
        }
    }
}
