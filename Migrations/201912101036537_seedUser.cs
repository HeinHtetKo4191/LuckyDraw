namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd37586fe-25a2-45f8-a34f-42dadb4ed96e', N'heinhtetko610@gmail.com', 0, N'AKKdW/RP2GrVyCaSRzkYIJQkjIeHkmCMqTosbmDGElAr4QjFHwoeTfVkSFjx4FZbqA==', N'd4150b91-328a-4be5-a7ef-8cb2fd8a7549', NULL, 0, 0, NULL, 1, 0, N'heinhtetko610@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f1a28f71-e51f-4c72-87b8-c5986fc244b2', N'admin@ucsm.com', 0, N'AHUW2xFpR3zPwjG2BH3kNMI5TSz0Pv7YS3wTcUlflry++zEjU9Qq0ERnmiOlfkCXGA==', N'4e5b86d6-a9f3-49a8-a20d-24ce2238c93c', NULL, 0, 0, NULL, 1, 0, N'admin@ucsm.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'83db7bcf-1fc9-42ca-8374-e1c5a9cc9462', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd37586fe-25a2-45f8-a34f-42dadb4ed96e', N'83db7bcf-1fc9-42ca-8374-e1c5a9cc9462')


");
        }
        
        public override void Down()
        {
        }
    }
}
