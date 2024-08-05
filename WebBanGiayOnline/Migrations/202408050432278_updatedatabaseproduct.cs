namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseproduct : DbMigration
    {
        public override void Up()
        {

            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id");
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender", "Id");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender", "Id", cascadeDelete: true);
        }
    }
}
