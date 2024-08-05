namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upnewtoday : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategory", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductGender", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "ProductGender_Id", "dbo.ProductGender");
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.Product", new[] { "ProductGenderId" });
            DropIndex("dbo.Product", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Product", new[] { "ProductGender_Id" });
            DropIndex("dbo.ProductCategory", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductGender", new[] { "Product_ProductId" });
            DropColumn("dbo.Product", "ProductCategoryId");
            DropColumn("dbo.Product", "ProductGenderId");
            RenameColumn(table: "dbo.Product", name: "ProductCategory_Id", newName: "ProductCategoryId");
            RenameColumn(table: "dbo.Product", name: "ProductGender_Id", newName: "ProductGenderId");
            AlterColumn("dbo.Product", "ProductCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ProductGenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "ProductCategoryId");
            CreateIndex("dbo.Product", "ProductGenderId");
            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductCategory", "Product_ProductId");
            DropColumn("dbo.ProductGender", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductGender", "Product_ProductId", c => c.Int());
            AddColumn("dbo.ProductCategory", "Product_ProductId", c => c.Int());
            DropForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropIndex("dbo.Product", new[] { "ProductGenderId" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            AlterColumn("dbo.Product", "ProductGenderId", c => c.Int());
            AlterColumn("dbo.Product", "ProductCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "ProductGenderId", newName: "ProductGender_Id");
            RenameColumn(table: "dbo.Product", name: "ProductCategoryId", newName: "ProductCategory_Id");
            AddColumn("dbo.Product", "ProductGenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductGender", "Product_ProductId");
            CreateIndex("dbo.ProductCategory", "Product_ProductId");
            CreateIndex("dbo.Product", "ProductGender_Id");
            CreateIndex("dbo.Product", "ProductCategory_Id");
            CreateIndex("dbo.Product", "ProductGenderId");
            CreateIndex("dbo.Product", "ProductCategoryId");
            AddForeignKey("dbo.Product", "ProductGender_Id", "dbo.ProductGender", "Id");
            AddForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory", "Id");
            AddForeignKey("dbo.ProductGender", "Product_ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.ProductCategory", "Product_ProductId", "dbo.Product", "ProductId");
        }
    }
}
