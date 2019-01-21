namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCreatedByDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.OfficeAssignments", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.OfficeAssignments", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String());
            AlterColumn("dbo.People", "UpdatedBy", c => c.String());
            AlterColumn("dbo.People", "CreatedBy", c => c.String());
            AlterColumn("dbo.OfficeAssignments", "UpdatedBy", c => c.String());
            AlterColumn("dbo.OfficeAssignments", "CreatedBy", c => c.String());
            AlterColumn("dbo.Departments", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Departments", "CreatedBy", c => c.String());
            AlterColumn("dbo.Courses", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Courses", "CreatedBy", c => c.String());
        }
    }
}
