namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suth : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Product", "ProductCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "ProductCode" });
        }
    }
}
