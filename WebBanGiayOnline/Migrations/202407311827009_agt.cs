namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
