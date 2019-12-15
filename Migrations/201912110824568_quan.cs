namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WinningNumbers", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WinningNumbers", "Quantity");
        }
    }
}
