namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetail", "ColorId", "dbo.Color");
            DropIndex("dbo.ProductDetail", new[] { "ColorId" });
            AddColumn("dbo.Product", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetail", "Stock", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "IsHome");
            DropColumn("dbo.Product", "IsSale");
            DropColumn("dbo.Product", "IsFeature");
            DropColumn("dbo.Product", "IsHot");
            DropColumn("dbo.Product", "IsActive");
            DropColumn("dbo.ProductDetail", "ColorId");
            DropColumn("dbo.ProductDetail", "Quatity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetail", "Quatity", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDetail", "ColorId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsFeature", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsHome", c => c.Boolean(nullable: false));
            DropColumn("dbo.ProductDetail", "Stock");
            DropColumn("dbo.Product", "Status");
            CreateIndex("dbo.ProductDetail", "ColorId", unique: true);
            AddForeignKey("dbo.ProductDetail", "ColorId", "dbo.Color", "ColorId", cascadeDelete: true);
        }
    }
}
