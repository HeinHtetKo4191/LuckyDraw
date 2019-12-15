namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "IsAwarded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "IsAwarded");
        }
    }
}
