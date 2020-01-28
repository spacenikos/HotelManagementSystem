namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "MealPicture", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "MealPicture");
        }
    }
}
