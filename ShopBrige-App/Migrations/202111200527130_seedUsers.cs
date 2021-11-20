namespace ShopBrige_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'051df81b-b6c7-4678-ae0e-fedfaf261d04', N'guest@shopbridge.com', 0, N'ABZL4YGeGfADYQU2VFI+aGz5zlAQ2qHbFP9ATcmEfKW+I5IO0XMQ+dHdmJJGdaCk1g==', N'b3d76273-7704-4d7f-b4ee-e406aba52095', NULL, 0, 0, NULL, 1, 0, N'guest@shopbridge.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4428bea4-c449-41b4-91c3-df51689b3f04', N'admin@shopbridge.com', 0, N'AGc1BJ1Nf2xrx7SH0+HojMOsQ0ZNc49lwB5cuSxPxESeSAU5ihMocPAHvXj2/NsxAA==', N'1d033b29-ff50-466f-8e22-3ab49f5ad338', NULL, 0, 0, NULL, 1, 0, N'admin@shopbridge.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'97c9250e-c19e-44f3-9e1f-1cbf5e49de16', N'CanManageItem')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4428bea4-c449-41b4-91c3-df51689b3f04', N'97c9250e-c19e-44f3-9e1f-1cbf5e49de16')
");
        }
        
        public override void Down()
        {
        }
    }
}
