namespace MVCCodeFirstTask1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentDetailsID = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentDetailsID)
                .ForeignKey("dbo.Students", t => t.StudentDetailsID)
                .Index(t => t.StudentDetailsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetails", "StudentDetailsID", "dbo.Students");
            DropIndex("dbo.StudentDetails", new[] { "StudentDetailsID" });
            DropTable("dbo.StudentDetails");
        }
    }
}
