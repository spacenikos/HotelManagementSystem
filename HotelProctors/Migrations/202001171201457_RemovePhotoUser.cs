namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhotoUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
        }
    }
}
