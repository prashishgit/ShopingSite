namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bannertableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.Banners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Photo = c.String(maxLength: 50),
                        Title = c.String(),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Main.Banners");
        }
    }
}
