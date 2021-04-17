namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseentityinheritinCategoryentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("Item.Category", "RecordStatus", c => c.Int(nullable: false));
            AddColumn("Item.Category", "CreatedById", c => c.Guid());
            AddColumn("Item.Category", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("Item.Category", "IsDeleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("Item.Category", "IsDeleted");
            DropColumn("Item.Category", "CreatedDate");
            DropColumn("Item.Category", "CreatedById");
            DropColumn("Item.Category", "RecordStatus");
        }
    }
}
