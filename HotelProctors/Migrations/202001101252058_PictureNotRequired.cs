namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meals", "MealPicture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meals", "MealPicture", c => c.String(nullable: false));
        }
    }
}
