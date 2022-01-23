namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e3ca31b-ef99-4048-a8d1-2bb68cb40ea6', N'admin@vidly.com', 0, N'ALEQF99DkLYtb6RsjPLLSEhlo3Nqy+JQbxeUE4lYwOdmGEpauM7qwsEQbB6xXnaaPw==', N'566dcb02-c9c3-4847-9541-15f1010c46e9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc3438a2-1d7a-46c6-b86f-b2a5373e2c26', N'guest@vidly.com', 0, N'APmxSqfQEuuE+cRJ9+WkXJkccNiz43sn0RLbFY97dVU44Jn71Z7DpDFP3CFF1sCOKA==', N'7b2f15b1-29c2-421e-bbc1-76a46352268f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd3fa0122-2451-4926-a7af-502d524361c0', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e3ca31b-ef99-4048-a8d1-2bb68cb40ea6', N'd3fa0122-2451-4926-a7af-502d524361c0')

");
        }
        
        public override void Down()
        {
        }
    }
}
