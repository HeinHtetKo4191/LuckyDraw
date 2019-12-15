namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernotnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WinningNumbers", "User", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WinningNumbers", "User", c => c.String(nullable: false));
        }
    }
}
