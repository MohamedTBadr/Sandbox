namespace Sandbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatchUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Tasks", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "DeletedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tasks", "User_Id");
            AddForeignKey("dbo.Tasks", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "User_Id" });
            DropColumn("dbo.Tasks", "User_Id");
            DropColumn("dbo.Tasks", "DeletedAt");
            DropColumn("dbo.Tasks", "UpdatedAt");
            DropColumn("dbo.Tasks", "CreatedAt");
            DropColumn("dbo.Tasks", "UserId");
        }
    }
}
