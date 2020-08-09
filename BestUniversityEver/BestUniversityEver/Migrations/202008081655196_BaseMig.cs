namespace BestUniversityEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Long(nullable: false, identity: true),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Course_CourseID = c.Long(),
                        Student_StudentID = c.Long(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .ForeignKey("dbo.Student", t => t.Student_StudentID)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Long(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        BirthDay = c.DateTime(),
                        Subject_SubjectID = c.Long(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID)
                .Index(t => t.Subject_SubjectID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Long(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Course_CourseID = c.Long(),
                        Teacher_TeacherID = c.Long(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherID)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Teacher_TeacherID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherID = c.Long(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        BirthDay = c.DateTime(),
                        Course_CourseID = c.Long(),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeID = c.Long(nullable: false, identity: true),
                        GradeValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Student_StudentID = c.Long(),
                        Subject_SubjectID = c.Long(),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.Student", t => t.Student_StudentID)
                .ForeignKey("dbo.Subject", t => t.Subject_SubjectID)
                .Index(t => t.Student_StudentID)
                .Index(t => t.Subject_SubjectID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Long(nullable: false, identity: true),
                        Author = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grade", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Grade", "Student_StudentID", "dbo.Student");
            DropForeignKey("dbo.Subject", "Teacher_TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Teacher", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.Student", "Subject_SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Subject", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "Student_StudentID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.Grade", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Grade", new[] { "Student_StudentID" });
            DropIndex("dbo.Teacher", new[] { "Course_CourseID" });
            DropIndex("dbo.Subject", new[] { "Teacher_TeacherID" });
            DropIndex("dbo.Subject", new[] { "Course_CourseID" });
            DropIndex("dbo.Student", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Enrollment", new[] { "Student_StudentID" });
            DropIndex("dbo.Enrollment", new[] { "Course_CourseID" });
            DropTable("dbo.Post");
            DropTable("dbo.Grade");
            DropTable("dbo.Teacher");
            DropTable("dbo.Subject");
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Course");
        }
    }
}
