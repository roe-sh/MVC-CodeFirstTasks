namespace MVCCodeFirstTask1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teachers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Teachers", t => t.id)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "id", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "id" });
            DropTable("dbo.Classes");
        }
    }
}
