namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Telephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
            DropColumn("dbo.AspNetUsers", "Telephone");
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "Firstname");
        }
    }
}
