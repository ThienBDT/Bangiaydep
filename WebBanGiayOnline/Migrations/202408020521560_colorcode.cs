namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colorcode : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetail", "ColorId", "dbo.Color");
            DropIndex("dbo.ProductDetail", new[] { "ColorId" });
            RenameColumn(table: "dbo.ProductDetail", name: "ColorId", newName: "ColorCode");
            DropPrimaryKey("dbo.Color");
            AlterColumn("dbo.Color", "ColorCode", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.ProductDetail", "ColorCode", c => c.String(maxLength: 7));
            AddPrimaryKey("dbo.Color", "ColorCode");
            CreateIndex("dbo.ProductDetail", "ColorCode");
            AddForeignKey("dbo.ProductDetail", "ColorCode", "dbo.Color", "ColorCode");
            DropColumn("dbo.Color", "ColorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Color", "ColorId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProductDetail", "ColorCode", "dbo.Color");
            DropIndex("dbo.ProductDetail", new[] { "ColorCode" });
            DropPrimaryKey("dbo.Color");
            AlterColumn("dbo.ProductDetail", "ColorCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Color", "ColorCode", c => c.String(maxLength: 7));
            AddPrimaryKey("dbo.Color", "ColorId");
            RenameColumn(table: "dbo.ProductDetail", name: "ColorCode", newName: "ColorId");
            CreateIndex("dbo.ProductDetail", "ColorId");
            AddForeignKey("dbo.ProductDetail", "ColorId", "dbo.Color", "ColorId", cascadeDelete: true);
        }
    }
}
