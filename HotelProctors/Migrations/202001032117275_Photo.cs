namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "ProfilePicture");
        }
    }
}
