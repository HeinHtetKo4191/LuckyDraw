namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Prices", "IsAwarded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prices", "IsAwarded", c => c.Boolean(nullable: false));
        }
    }
}
