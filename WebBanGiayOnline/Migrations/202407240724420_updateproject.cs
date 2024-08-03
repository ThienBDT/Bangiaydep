namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ColorId", c => c.String());
            AddColumn("dbo.Product", "Color_ColorId", c => c.Int());
            CreateIndex("dbo.Product", "Color_ColorId");
            AddForeignKey("dbo.Product", "Color_ColorId", "dbo.Color", "ColorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Color_ColorId", "dbo.Color");
            DropIndex("dbo.Product", new[] { "Color_ColorId" });
            DropColumn("dbo.Product", "Color_ColorId");
            DropColumn("dbo.Product", "ColorId");
        }
    }
}
