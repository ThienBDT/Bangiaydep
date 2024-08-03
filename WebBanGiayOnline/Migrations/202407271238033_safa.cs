namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class safa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adv", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Adv", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Category", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Category", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.News", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.News", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ProductDetail", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductDetail", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Order", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Order", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Customer", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Customer", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Status", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Status", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Product", "PriceSale", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ProductCategory", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductCategory", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ProductDetailImage", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductDetailImage", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ProductGender", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductGender", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Contact", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Contact", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductGender", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductGender", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetailImage", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetailImage", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCategory", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCategory", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product", "PriceSale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Status", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Status", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetail", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductDetail", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.News", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.News", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Category", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Category", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adv", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adv", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
