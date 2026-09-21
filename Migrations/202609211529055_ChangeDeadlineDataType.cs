namespace Sandbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeadlineDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Deadline", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Deadline", c => c.String());
        }
    }
}
