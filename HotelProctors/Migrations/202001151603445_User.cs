namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Rooms", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "ApplicationUser_Id", c => c.String(maxLength: 128));
        
            CreateIndex("dbo.Rooms", "ApplicationUser_Id");
            AddForeignKey("dbo.Rooms", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
