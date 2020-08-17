namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroptableUserGroupandGroupalsoaddedforeignkeyinroleDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("User.UserGroups", "GroupId", "User.Group");
            DropForeignKey("User.UserGroups", "UserId", "User.Users");
            DropIndex("User.UserGroups", new[] { "GroupId" });
            DropIndex("User.UserGroups", new[] { "UserId" });
            AddColumn("User.RoleDetails", "UserId", c => c.Guid(nullable: false));
            CreateIndex("User.RoleDetails", "RoleId");
            CreateIndex("User.RoleDetails", "UserId");
            AddForeignKey("User.RoleDetails", "RoleId", "User.Roles", "Id", cascadeDelete: true);
            AddForeignKey("User.RoleDetails", "UserId", "User.Users", "Id", cascadeDelete: true);
            DropTable("User.Group");
            DropTable("User.UserGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "User.UserGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupId = c.Guid(nullable: false),
                        UserId = c.Guid(),
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "User.Group",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Order = c.Int(),
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("User.RoleDetails", "UserId", "User.Users");
            DropForeignKey("User.RoleDetails", "RoleId", "User.Roles");
            DropIndex("User.RoleDetails", new[] { "UserId" });
            DropIndex("User.RoleDetails", new[] { "RoleId" });
            DropColumn("User.RoleDetails", "UserId");
            CreateIndex("User.UserGroups", "UserId");
            CreateIndex("User.UserGroups", "GroupId");
            AddForeignKey("User.UserGroups", "UserId", "User.Users", "Id");
            AddForeignKey("User.UserGroups", "GroupId", "User.Group", "Id", cascadeDelete: true);
        }
    }
}
