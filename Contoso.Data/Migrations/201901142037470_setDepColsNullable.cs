namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setDepColsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Departments", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "UpdatedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
