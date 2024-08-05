namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "TypePayment", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Note", c => c.String());
            DropColumn("dbo.Order", "TypePayment");
        }
    }
}
