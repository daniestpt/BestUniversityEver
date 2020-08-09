namespace BestUniversityEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseMig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "Subject_SubjectID", "dbo.Subject");
            DropIndex("dbo.Student", new[] { "Subject_SubjectID" });
            DropColumn("dbo.Student", "Subject_SubjectID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Subject_SubjectID", c => c.Long());
            CreateIndex("dbo.Student", "Subject_SubjectID");
            AddForeignKey("dbo.Student", "Subject_SubjectID", "dbo.Subject", "SubjectID");
        }
    }
}
