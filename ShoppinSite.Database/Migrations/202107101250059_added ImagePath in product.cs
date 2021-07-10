namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImagePathinproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Item.Products", "ImagePath", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("Item.Products", "ImagePath");
        }
    }
}
