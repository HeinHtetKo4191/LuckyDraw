namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WinningNumbers", "Quantity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WinningNumbers", "Quantity", c => c.Int(nullable: false));
        }
    }
}
