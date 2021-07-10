namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIdaddedasaforeignkeyinproducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("Item.Products", "CategoryId", c => c.Guid(nullable: false));
            CreateIndex("Item.Products", "CategoryId");
            AddForeignKey("Item.Products", "CategoryId", "Item.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Item.Products", "CategoryId", "Item.Category");
            DropIndex("Item.Products", new[] { "CategoryId" });
            DropColumn("Item.Products", "CategoryId");
        }
    }
}
