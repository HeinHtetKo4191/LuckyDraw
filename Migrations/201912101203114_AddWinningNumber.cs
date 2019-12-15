namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWinningNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WinningNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.WinningNumbers", new[] { "Number" });
            DropTable("dbo.WinningNumbers");
        }
    }
}
