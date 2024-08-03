namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNewsModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CreatedBy", c => c.String());
            AddColumn("dbo.Posts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "ModifiedBy", c => c.String());
            AddColumn("dbo.Posts", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ModifiedDate");
            DropColumn("dbo.Posts", "ModifiedBy");
            DropColumn("dbo.Posts", "CreatedDate");
            DropColumn("dbo.Posts", "CreatedBy");
        }
    }
}
