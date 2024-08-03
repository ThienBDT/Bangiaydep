namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodell11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetail", "Product_ProductId1", "dbo.Product");
            DropForeignKey("dbo.ProductDetail", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.ProductDetail", new[] { "ProductId" });
            DropIndex("dbo.ProductDetail", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductDetail", new[] { "Product_ProductId1" });
            DropColumn("dbo.ProductDetail", "ProductId");
            RenameColumn(table: "dbo.ProductDetail", name: "Product_ProductId", newName: "ProductId");
            AlterColumn("dbo.ProductDetail", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductDetail", "ProductId", unique: true);
            AddForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
            DropColumn("dbo.ProductDetail", "Product_ProductId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetail", "Product_ProductId1", c => c.Int());
            DropForeignKey("dbo.ProductDetail", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductDetail", new[] { "ProductId" });
            AlterColumn("dbo.ProductDetail", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.ProductDetail", name: "ProductId", newName: "Product_ProductId");
            AddColumn("dbo.ProductDetail", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductDetail", "Product_ProductId1");
            CreateIndex("dbo.ProductDetail", "Product_ProductId");
            CreateIndex("dbo.ProductDetail", "ProductId", unique: true);
            AddForeignKey("dbo.ProductDetail", "Product_ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.ProductDetail", "Product_ProductId1", "dbo.Product", "ProductId");
        }
    }
}
