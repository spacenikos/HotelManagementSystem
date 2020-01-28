namespace HotelProctors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoFinal : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Photos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
