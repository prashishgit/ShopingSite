namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdate : DbMigration
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
                "Base.ErrorLoggers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ControllerName = c.String(maxLength: 50, unicode: false),
                        ExceptionMessage = c.String(maxLength: 2000),
                        ExceptionStackTrace = c.String(maxLength: 4000),
                        LogTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedNepaliDate = c.String(maxLength: 20, unicode: false),
                        NepaliLogTime = c.String(maxLength: 20, unicode: false),
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 35),
                        MiddleName = c.String(maxLength: 35),
                        LastName = c.String(maxLength: 35),
                        FullName = c.String(maxLength: 105),
                        TitleOfCourtesy = c.String(maxLength: 10, unicode: false),
                        Gender = c.String(maxLength: 10, unicode: false),
                        State = c.String(maxLength: 35),
                        District = c.String(maxLength: 35),
                        VDCMunicipality = c.String(maxLength: 35),
                        LocalAddress = c.String(maxLength: 35),
                        CreatedDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("User.RoleDetails", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("User.RoleDetails", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("User.RoleDetails", new[] { "UserId" });
            DropIndex("User.RoleDetails", new[] { "RoleId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("User.RoleDetails");
            DropTable("Item.Products");
            DropTable("Base.ErrorLoggers");
            DropTable("Main.Banners");
        }
    }
}
