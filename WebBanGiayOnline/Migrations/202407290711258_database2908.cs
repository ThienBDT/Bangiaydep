namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database2908 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.OrderDetail", "Product_ProductId");
            AddForeignKey("dbo.OrderDetail", "Product_ProductId", "dbo.Product", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "Product_ProductId" });
            DropColumn("dbo.OrderDetail", "Product_ProductId");
        }
    }
}
