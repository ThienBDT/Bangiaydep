namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataProductCategoryModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "Alias", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.ProductCategory", "Icon", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductCategory", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductCategory", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.ProductCategory", "SeoKeyWords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategory", "SeoKeyWords", c => c.String());
            AlterColumn("dbo.ProductCategory", "SeoDescription", c => c.String());
            AlterColumn("dbo.ProductCategory", "SeoTitle", c => c.String());
            AlterColumn("dbo.ProductCategory", "Icon", c => c.String());
            DropColumn("dbo.ProductCategory", "Alias");
        }
    }
}
