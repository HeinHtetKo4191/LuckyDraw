namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringLe : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.WinningNumbers", name: "IX_Number", newName: "Ix_ProductName");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WinningNumbers", name: "Ix_ProductName", newName: "IX_Number");
        }
    }
}
