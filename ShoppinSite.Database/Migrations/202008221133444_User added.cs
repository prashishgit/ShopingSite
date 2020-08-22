namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Useradded : DbMigration
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
            
            CreateTable(
                "Item.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "User.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "User.RoleDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MenuName = c.String(),
                        CanView = c.Boolean(nullable: false),
                        CanCreate = c.Boolean(nullable: false),
                        CanEdit = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                        CanRecommend = c.Boolean(nullable: false),
                        CanCheck = c.Boolean(nullable: false),
                        CanApprove = c.Boolean(nullable: false),
                        CanDownload = c.Boolean(nullable: false),
                        CanReject = c.Boolean(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("User.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "User.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(nullable: false),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("User.RoleDetails", "UserId", "User.Users");
            DropForeignKey("User.RoleDetails", "RoleId", "User.Roles");
            DropIndex("User.RoleDetails", new[] { "UserId" });
            DropIndex("User.RoleDetails", new[] { "RoleId" });
            DropTable("User.Users");
            DropTable("User.RoleDetails");
            DropTable("User.Roles");
            DropTable("Item.Products");
            DropTable("Main.Banners");
        }
    }
}
