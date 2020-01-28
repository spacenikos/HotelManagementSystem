namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePicture : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "MealPicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "MealPicture", c => c.String());
        }
    }
}
