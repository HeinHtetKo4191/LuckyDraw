namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WinningNumbers", "AllQuentity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WinningNumbers", "AllQuentity");
        }
    }
}
