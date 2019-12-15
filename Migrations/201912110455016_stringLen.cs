namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringLen : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.WinningNumbers", new[] { "Number" });
            AlterColumn("dbo.WinningNumbers", "Number", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.WinningNumbers", "Number", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.WinningNumbers", new[] { "Number" });
            AlterColumn("dbo.WinningNumbers", "Number", c => c.Int(nullable: false));
            CreateIndex("dbo.WinningNumbers", "Number", unique: true);
        }
    }
}
