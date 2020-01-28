namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            AlterColumn("dbo.Rooms", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            AlterColumn("dbo.Rooms", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
