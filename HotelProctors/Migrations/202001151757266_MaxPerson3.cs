namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxPerson3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "MaxPersons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "MaxPersons", c => c.Int(nullable: false));
        }
    }
}
