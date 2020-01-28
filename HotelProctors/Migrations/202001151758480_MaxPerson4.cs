namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxPerson4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "MaxPersons", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "MaxPersons");
        }
    }
}
