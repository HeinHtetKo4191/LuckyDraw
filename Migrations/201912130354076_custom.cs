namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class custom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "Winner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "Winner");
        }
    }
}
