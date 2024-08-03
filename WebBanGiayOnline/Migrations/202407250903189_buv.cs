namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Color_ColorId", "dbo.Color");
            DropIndex("dbo.Product", new[] { "Color_ColorId" });
            AddColumn("dbo.Product", "IsHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsFeature", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductDetail", "ColorId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductDetail", "ColorId");
            AddForeignKey("dbo.ProductDetail", "ColorId", "dbo.Color", "ColorId", cascadeDelete: true);
            DropColumn("dbo.Product", "ColorId");
            DropColumn("dbo.Product", "Status");
            DropColumn("dbo.Product", "Color_ColorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Color_ColorId", c => c.Int());
            AddColumn("dbo.Product", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ColorId", c => c.String());
            DropForeignKey("dbo.ProductDetail", "ColorId", "dbo.Color");
            DropIndex("dbo.ProductDetail", new[] { "ColorId" });
            DropColumn("dbo.ProductDetail", "ColorId");
            DropColumn("dbo.Product", "IsActive");
            DropColumn("dbo.Product", "IsHot");
            DropColumn("dbo.Product", "IsFeature");
            DropColumn("dbo.Product", "IsSale");
            DropColumn("dbo.Product", "IsHome");
            CreateIndex("dbo.Product", "Color_ColorId");
            AddForeignKey("dbo.Product", "Color_ColorId", "dbo.Color", "ColorId");
        }
    }
}
