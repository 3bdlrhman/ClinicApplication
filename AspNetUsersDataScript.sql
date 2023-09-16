USE [aspnet-ClinicApplication]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'265a2a63-3706-46d7-975e-742db7e4f431', N'Secretary', N'SECRETARY', N'880427ae-2e85-41d9-8bb6-2215c5373291')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'60de8c7b-a015-4f27-aa91-4e5270c9126e', N'Admin', N'ADMIN', N'c5620276-f4bf-4d63-b353-cc99ef304740')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'30144567-4cb2-4865-a4be-8e1a783064f4', N'AdminUser@email.com', N'ADMINUSER@EMAIL.COM', N'AdminUser@email.com', N'ADMINUSER@EMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOCOdVOt4i8tYj/76ksGBFkT8U+2+WQSEasRrj4Maqx5F464bfe5PgyPGbZiji10Dw==', N'KS4UB5PQBKMWALR3ZVFKX4SCYBCXTVM7', N'6871c32c-1aa2-411e-adeb-c445ec396083', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'977305d3-c093-4399-90d6-f000ff154016', N'SecretaryUser@email.com', N'SECRETARYUSER@EMAIL.COM', N'SecretaryUser@email.com', N'SECRETARYUSER@EMAIL.COM', 0, N'AQAAAAEAACcQAAAAELg9RrvNbePAbIatfnd4osGCYFolPmOs8Dpm9RokEXyMgULUfB6OCkFaG1bB/vsh7w==', N'ZZHY2YAU4TD3UFURJSPAA45RHFYRH4D7', N'a5b177db-502a-4b83-8bb4-b42c652e8b2e', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9d457259-b29c-47a0-b5aa-738a0e30fd64', N'abdo@gmail.com', N'ABDO@GMAIL.COM', N'abdo@gmail.com', N'ABDO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEByGNfw39WY9CThGsOtOq7gGWvDJzPIUTO7bzyMmdrYqFvUwura1sand+g+b07aCXQ==', N'MI733PJMJJR5UNA2FAYQ67G3NQAADW6C', N'39f58a9c-3383-49f2-a247-ca674b55c461', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e4a6ba49-decf-4651-b576-d1dbb7493883', N'admin@email.com', N'ADMIN@EMAIL.COM', N'admin@email.com', N'ADMIN@EMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBVqI/VQnIP1YeRfXrdx8HwQIXoOSCBzsgMZeZI+Qr2p0ffmIRq/A06XT67WeFrtkw==', N'LXSUIH7YJ27XNYBTYHNAGW3YOLIGRRDE', N'16650d4c-e30f-40f9-901e-716e1309ea45', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'977305d3-c093-4399-90d6-f000ff154016', N'265a2a63-3706-46d7-975e-742db7e4f431')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'30144567-4cb2-4865-a4be-8e1a783064f4', N'60de8c7b-a015-4f27-aa91-4e5270c9126e')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.21')
GO
