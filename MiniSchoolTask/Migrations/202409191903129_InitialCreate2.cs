namespace MiniSchoolTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tasks", "TaskDetails", c => c.String(nullable: false));
            DropColumn("dbo.Subjects", "Details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Details", c => c.String());
            AlterColumn("dbo.Tasks", "TaskDetails", c => c.String());
            AlterColumn("dbo.Tasks", "TaskName", c => c.String());
        }
    }
}
