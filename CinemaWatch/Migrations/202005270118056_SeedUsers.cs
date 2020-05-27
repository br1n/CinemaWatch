namespace CinemaWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'329bb813-7e06-4001-9f36-16ee60e83f39', N'admin@CinemaWatch.com', 0, N'ANdwLVRqySR2qYy2b7js47iOD31xM4ZXQI0R7oQLToJKCIfGkA+FwoZQSlNjaYqcEg==', N'76db6d3e-4805-423a-8bfd-2ff297a736ad', NULL, 0, 0, NULL, 1, 0, N'admin@CinemaWatch.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e16332d6-c220-4766-8f5a-6adf95dc4203', N'guest@CinemaWatch.com', 0, N'AD3d8mnFUGbHtraOApwiDqcLqQAgpyPbFOcHPECiPawMFZw+bJR3/oScP4e9ctEdrw==', N'460970cd-75c0-434b-9d02-f8026e3dba1d', NULL, 0, 0, NULL, 1, 0, N'guest@CinemaWatch.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'683c9525-1f9c-49ab-b0b5-fc139a770adf', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'329bb813-7e06-4001-9f36-16ee60e83f39', N'683c9525-1f9c-49ab-b0b5-fc139a770adf')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
