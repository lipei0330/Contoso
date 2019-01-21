namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDeleteFunc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "EnrollmentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
    }
}
