namespace WebBanGiayOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolornew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Color", "ColorCode", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Color", "ColorCode");
        }
    }
}
