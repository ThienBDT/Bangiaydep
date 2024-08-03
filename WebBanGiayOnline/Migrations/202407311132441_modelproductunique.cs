namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelproductunique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductDetail", new[] { "ProductId" });
            CreateIndex("dbo.ProductDetail", "ProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductDetail", new[] { "ProductId" });
            CreateIndex("dbo.ProductDetail", "ProductId", unique: true);
        }
    }
}
