namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "isAwarded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "isAwarded");
        }
    }
}
