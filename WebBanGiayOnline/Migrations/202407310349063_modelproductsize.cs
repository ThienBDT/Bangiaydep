namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelproductsize : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductDetail", new[] { "SizeId" });
            CreateIndex("dbo.ProductDetail", "SizeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductDetail", new[] { "SizeId" });
            CreateIndex("dbo.ProductDetail", "SizeId", unique: true);
        }
    }
}
