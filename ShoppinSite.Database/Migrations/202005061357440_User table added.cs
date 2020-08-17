namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usertableadded : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "User.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
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
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "User.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 35),
                        MiddleName = c.String(maxLength: 35),
                        LastName = c.String(maxLength: 35),
                        FullName = c.String(maxLength: 35),
                        TitleOfCourtesy = c.String(maxLength: 10, unicode: false),
                        Gender = c.String(maxLength: 10),
                        District = c.String(),
                        VDCMunicipalaity = c.String(),
                        LocalAddress = c.String(maxLength: 35),
                        TelephoneNo = c.String(maxLength: 35),
                        RecordStatus = c.Int(nullable: false),
                        CreatedById = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("User.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("User.Users", t => t.UserId)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("User.UserGroups", "UserId", "User.Users");
            DropForeignKey("User.UserGroups", "GroupId", "User.Group");
            DropIndex("User.UserGroups", new[] { "UserId" });
            DropIndex("User.UserGroups", new[] { "GroupId" });
            DropTable("User.UserGroups");
            DropTable("User.Users");
            DropTable("User.RoleDetails");
            DropTable("User.Roles");
            DropTable("User.Group");
        }
    }
}
