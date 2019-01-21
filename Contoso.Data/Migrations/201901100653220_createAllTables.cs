namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createAllTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.People", "Id", "dbo.Instructors");
            DropForeignKey("dbo.RolePeoples", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RolePeoples", "People_Id", "dbo.People");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.People", "Id", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "InstructorId" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            DropIndex("dbo.People", new[] { "Id" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.RolePeoples", new[] { "Role_Id" });
            DropIndex("dbo.RolePeoples", new[] { "People_Id" });
            DropPrimaryKey("dbo.OfficeAssignments");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.OfficeAssignments", "InstructorId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OfficeAssignments", "InstructorId");
            AddPrimaryKey("dbo.People", "Id");
            DropColumn("dbo.Courses", "DepartmentId");
            DropColumn("dbo.Departments", "InstructorId");
            DropTable("dbo.Enrollments");
            DropTable("dbo.RolePeoples");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RolePeoples",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        People_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.People_Id });
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Departments", "InstructorId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.OfficeAssignments");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.OfficeAssignments", "InstructorId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.People", "Id");
            AddPrimaryKey("dbo.OfficeAssignments", "InstructorId");
            CreateIndex("dbo.RolePeoples", "People_Id");
            CreateIndex("dbo.RolePeoples", "Role_Id");
            CreateIndex("dbo.Enrollments", "StudentId");
            CreateIndex("dbo.Enrollments", "CourseId");
            CreateIndex("dbo.People", "Id");
            CreateIndex("dbo.OfficeAssignments", "InstructorId");
            CreateIndex("dbo.Departments", "InstructorId");
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.People", "Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Enrollments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RolePeoples", "People_Id", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RolePeoples", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "Id", "dbo.Instructors", "Id");
            AddForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors", "Id");
            AddForeignKey("dbo.Departments", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
