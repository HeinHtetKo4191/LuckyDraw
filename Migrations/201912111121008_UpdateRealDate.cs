namespace LuckyD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRealDate : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ae471cff-fe77-44bf-9aa1-0258993e23b6', N'admin@ucsm.com', 0, N'AIOsNs5Kd1hqHSQY2NJXG2/uaw4QTgJe//bd2sAq9t0ebbvjE4Yc8c1wkYfuAKlKqQ==', N'c1736d10-9a58-4095-af0b-d4c2fc394911', NULL, 0, 0, NULL, 1, 0, N'admin@ucsm.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b8551e68-3dde-40c4-a4f3-4d6e49ada316', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ae471cff-fe77-44bf-9aa1-0258993e23b6', N'b8551e68-3dde-40c4-a4f3-4d6e49ada316')


");
        }
        
        public override void Down()
        {
        }
    }
}
