namespace ShoppinSite.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorLogger : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("Base.ErrorLoggers");
        }
    }
}
