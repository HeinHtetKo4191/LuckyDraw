namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Extra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "AwardedNumber", c => c.String());
            AddColumn("dbo.WinningNumbers", "IsWinner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WinningNumbers", "IsWinner");
            DropColumn("dbo.Prices", "AwardedNumber");
        }
    }
}
