namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxPersons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "maxPersons", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "maxPersons");
        }
    }
}
