namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Category", new[] { "CategoryName" });
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 100));
            CreateIndex("dbo.Category", "CategoryName", unique: true);
        }
    }
}
