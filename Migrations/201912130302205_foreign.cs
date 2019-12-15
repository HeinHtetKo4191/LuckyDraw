namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WinningNumbers", "PriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.WinningNumbers", "PriceId");
            AddForeignKey("dbo.WinningNumbers", "PriceId", "dbo.Prices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WinningNumbers", "PriceId", "dbo.Prices");
            DropIndex("dbo.WinningNumbers", new[] { "PriceId" });
            DropColumn("dbo.WinningNumbers", "PriceId");
        }
    }
}
