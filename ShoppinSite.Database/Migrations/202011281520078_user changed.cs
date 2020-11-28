namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "User.Roles", newName: "AspNetRoles");
            RenameTable(name: "User.Users", newName: "AspNetUsers");
            MoveTable(name: "User.AspNetRoles", newSchema: "dbo");
            MoveTable(name: "User.AspNetUsers", newSchema: "dbo");
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
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 35));
            AddColumn("dbo.AspNetUsers", "MiddleName", c => c.String(maxLength: 35));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 35));
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 105));
            AddColumn("dbo.AspNetUsers", "TitleOfCourtesy", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String(maxLength: 35));
            AddColumn("dbo.AspNetUsers", "District", c => c.String(maxLength: 35));
            AddColumn("dbo.AspNetUsers", "VDCMunicipality", c => c.String(maxLength: 35));
            AddColumn("dbo.AspNetUsers", "LocalAddress", c => c.String(maxLength: 35));
            AddColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            DropColumn("dbo.AspNetUsers", "RecordStatus");
            DropColumn("dbo.AspNetUsers", "CreatedById");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "CreatedById", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "RecordStatus", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "SecurityStamp");
            DropColumn("dbo.AspNetUsers", "LocalAddress");
            DropColumn("dbo.AspNetUsers", "VDCMunicipality");
            DropColumn("dbo.AspNetUsers", "District");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "TitleOfCourtesy");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "MiddleName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            MoveTable(name: "dbo.AspNetUsers", newSchema: "User");
            MoveTable(name: "dbo.AspNetRoles", newSchema: "User");
            RenameTable(name: "User.AspNetUsers", newName: "Users");
            RenameTable(name: "User.AspNetRoles", newName: "Roles");
        }
    }
}
