namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodelproduct1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory");
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.Product", new[] { "ProductCategory_Id" });
            DropColumn("dbo.Product", "ProductCategoryId");
            RenameColumn(table: "dbo.Product", name: "ProductCategory_Id", newName: "ProductCategoryId");
            AlterColumn("dbo.Product", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "ProductCategoryId");
            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            AlterColumn("dbo.Product", "ProductCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "ProductCategoryId", newName: "ProductCategory_Id");
            AddColumn("dbo.Product", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "ProductCategory_Id");
            CreateIndex("dbo.Product", "ProductCategoryId");
            AddForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory", "Id");
        }
    }
}
