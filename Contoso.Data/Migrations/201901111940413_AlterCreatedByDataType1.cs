namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCreatedByDataType1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollments", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Enrollments", "UpdatedBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Enrollments", "CreatedBy", c => c.String());
        }
    }
}
