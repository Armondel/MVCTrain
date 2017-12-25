namespace MVCTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1c28aa7b-4ee4-434f-85a0-c1b5830cd988', N'manager@hellgate.com', 0, N'AAb2GNs9PSiqcKMBbV1hcwXrmPhXZ0/usLCXNo7UWQtrIUDvygG8Z9NGFVNvfuOt5Q==', N'c1fd7fc3-3d63-4429-991c-e865640fb882', NULL, 0, 0, NULL, 1, 0, N'manager@hellgate.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c4aad279-2a03-4121-b210-04fa94c13f42', N'guest@hellgate.com', 0, N'AG0xMyDOA56f3W7pdvNlHyHN5Di5K9bWViXPlP/TO86cb9ZOfF1aRTWfUgq8GzK/Lg==', N'bb9a1fa1-224f-4c6e-89ca-6c731c9eb03f', NULL, 0, 0, NULL, 1, 0, N'guest@hellgate.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'84fefb47-e893-4979-ac96-9c6ce9b71763', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1c28aa7b-4ee4-434f-85a0-c1b5830cd988', N'84fefb47-e893-4979-ac96-9c6ce9b71763')");
        }

        public override void Down()
        {
        }
    }
}
