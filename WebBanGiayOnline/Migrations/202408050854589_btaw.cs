namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateProductSchema : DbMigration
    {
        public override void Up()
        {
            // Rename columns if they have incorrect names
            RenameColumn(table: "dbo.Product", name: "ProductCategory_Id", newName: "ProductCategoryId");
            RenameColumn(table: "dbo.Product", name: "ProductGender_Id", newName: "ProductGenderId");

            // Ensure columns are of the correct type and not nullable
            AlterColumn("dbo.Product", "ProductCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ProductGenderId", c => c.Int(nullable: false));

            // Recreate foreign key constraints with cascade delete if needed
            AddForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender", "Id", cascadeDelete: true);

            // Recreate indices for the newly renamed columns
            CreateIndex("dbo.Product", "ProductCategoryId");
            CreateIndex("dbo.Product", "ProductGenderId");
        }

        public override void Down()
        {
            // Drop the foreign key constraints
            DropForeignKey("dbo.Product", "ProductGenderId", "dbo.ProductGender");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");

            // Remove indices if they were previously created
            DropIndex("dbo.Product", new[] { "ProductGenderId" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });

            // Rename columns back to their original names if needed
            RenameColumn(table: "dbo.Product", name: "ProductGenderId", newName: "ProductGender_Id");
            RenameColumn(table: "dbo.Product", name: "ProductCategoryId", newName: "ProductCategory_Id");

            // Alter columns back to their original states if needed
            AlterColumn("dbo.Product", "ProductCategory_Id", c => c.Int());
            AlterColumn("dbo.Product", "ProductGender_Id", c => c.Int());

            // Recreate foreign key constraints to match original setup
            AddForeignKey("dbo.Product", "ProductCategory_Id", "dbo.ProductCategory", "Id");
            AddForeignKey("dbo.Product", "ProductGender_Id", "dbo.ProductGender", "Id");

            // Recreate indices for original column names if needed
            CreateIndex("dbo.Product", "ProductCategory_Id");
            CreateIndex("dbo.Product", "ProductGender_Id");
        }
    }
}
