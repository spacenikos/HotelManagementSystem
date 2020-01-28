namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arxiki2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "View", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "View", c => c.Int(nullable: false));
        }
    }
}
