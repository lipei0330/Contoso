namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createFK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Instructors");
            DropPrimaryKey("dbo.OfficeAssignments");
            DropPrimaryKey("dbo.Students");
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.RolePeoples",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        People_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.People_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.People_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.People_Id);
            
            AddColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "InstructorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Instructors", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.OfficeAssignments", "InstructorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Instructors", "Id");
            AddPrimaryKey("dbo.OfficeAssignments", "InstructorId");
            AddPrimaryKey("dbo.Students", "Id");
            CreateIndex("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.Departments", "InstructorId");
            CreateIndex("dbo.Instructors", "Id");
            CreateIndex("dbo.OfficeAssignments", "InstructorId");
            CreateIndex("dbo.Students", "Id");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors", "Id");
            AddForeignKey("dbo.Students", "Id", "dbo.People", "Id");
            AddForeignKey("dbo.Instructors", "Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "Id", "dbo.People");
            DropForeignKey("dbo.Students", "Id", "dbo.People");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.RolePeoples", "People_Id", "dbo.People");
            DropForeignKey("dbo.RolePeoples", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.RolePeoples", new[] { "People_Id" });
            DropIndex("dbo.RolePeoples", new[] { "Role_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            DropIndex("dbo.Instructors", new[] { "Id" });
            DropIndex("dbo.Departments", new[] { "InstructorId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.OfficeAssignments");
            DropPrimaryKey("dbo.Instructors");
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OfficeAssignments", "InstructorId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Instructors", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Departments", "InstructorId");
            DropColumn("dbo.Courses", "DepartmentId");
            DropTable("dbo.RolePeoples");
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.Enrollments");
            AddPrimaryKey("dbo.Students", "Id");
            AddPrimaryKey("dbo.OfficeAssignments", "InstructorId");
            AddPrimaryKey("dbo.Instructors", "Id");
        }
    }
}
