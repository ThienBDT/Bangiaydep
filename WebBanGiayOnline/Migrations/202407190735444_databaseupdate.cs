namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            CreateTable(
                "dbo.ProductGender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductGenderName = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(),
                        Icon = c.String(maxLength: 250),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeyWords = c.String(maxLength: 250),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ProductGenderName, unique: true);
            
            AddColumn("dbo.Product", "ProductGenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductCategory_Id", c => c.Int());
            CreateIndex("dbo.Product", "ProductGenderId");
            CreateIndex("dbo.Product", "ProductCategory_Id");
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductCategory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender");
            DropForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductCategory");
            DropIndex("dbo.ProductGender", new[] { "ProductGenderName" });
            DropIndex("dbo.Product", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Product", new[] { "ProductGenderId" });
            DropColumn("dbo.Product", "ProductCategory_Id");
            DropColumn("dbo.Product", "ProductGenderId");
            DropTable("dbo.ProductGender");
            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id", cascadeDelete: true);
        }
    }
}
