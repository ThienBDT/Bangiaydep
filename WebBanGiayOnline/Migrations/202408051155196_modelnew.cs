namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelnew : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Product", "ProductCategoryId");
            CreateIndex("dbo.Product", "ProductGenderId");
        }
    }
}
