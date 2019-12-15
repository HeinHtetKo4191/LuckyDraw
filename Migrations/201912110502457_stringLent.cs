namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringLent : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.WinningNumbers", name: "Ix_ProductName", newName: "IX_Number");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WinningNumbers", name: "IX_Number", newName: "Ix_ProductName");
        }
    }
}
