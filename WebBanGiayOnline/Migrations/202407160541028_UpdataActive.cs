namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "IsDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "IsActive");
            DropColumn("dbo.Posts", "IsActive");
            DropColumn("dbo.News", "IsActive");
            DropColumn("dbo.Category", "IsActive");
        }
    }
}
