namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodelproduct11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product");
            AddColumn("dbo.ProductDetail", "Product_ProductId", c => c.Int());
            AddColumn("dbo.ProductDetail", "Product_ProductId1", c => c.Int());
            CreateIndex("dbo.ProductDetail", "Product_ProductId");
            CreateIndex("dbo.ProductDetail", "Product_ProductId1");
            AddForeignKey("dbo.ProductDetail", "Product_ProductId1", "dbo.Product", "ProductId");
            AddForeignKey("dbo.ProductDetail", "Product_ProductId", "dbo.Product", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetail", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductDetail", "Product_ProductId1", "dbo.Product");
            DropIndex("dbo.ProductDetail", new[] { "Product_ProductId1" });
            DropIndex("dbo.ProductDetail", new[] { "Product_ProductId" });
            DropColumn("dbo.ProductDetail", "Product_ProductId1");
            DropColumn("dbo.ProductDetail", "Product_ProductId");
            AddForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
    }
}
