namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Alias", c => c.String());
            AddColumn("dbo.News", "Alias", c => c.String());
            AddColumn("dbo.Posts", "Alias", c => c.String());
            AddColumn("dbo.Product", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Alias");
            DropColumn("dbo.Posts", "Alias");
            DropColumn("dbo.News", "Alias");
            DropColumn("dbo.Category", "Alias");
        }
    }
}
