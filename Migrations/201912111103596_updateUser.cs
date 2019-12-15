namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd37586fe-25a2-45f8-a34f-42dadb4ed96e', N'heinhtetko610@ucsm.com', 0, N'AKKdW/RP2GrVyCaSRzkYIJQkjIeHkmCMqTosbmDGElAr4QjFHwoeTfVkSFjx4FZbqA==', N'd4150b91-328a-4be5-a7ef-8cb2fd8a7549', NULL, 0, 0, NULL, 1, 0, N'heinhtetko610@gmail.com')


");
        }
        
        public override void Down()
        {
        }
    }
}
