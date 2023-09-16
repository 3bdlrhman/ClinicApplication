USE [ClinicDb]
GO
SET IDENTITY_INSERT [dbo].[TBLClinic] ON 
GO
INSERT [dbo].[TBLClinic] ([ClinicID], [ClinicName], [ClinicAddress]) VALUES (1, N'Sample Clinic', N'123 Main Street')
GO
SET IDENTITY_INSERT [dbo].[TBLClinic] OFF
GO
SET IDENTITY_INSERT [dbo].[TBLDoctors] ON 
GO
INSERT [dbo].[TBLDoctors] ([DoctorID], [DoctorName], [About], [ClinicID]) VALUES (3, N'Ahmed', N'First Class', 1)
GO
INSERT [dbo].[TBLDoctors] ([DoctorID], [DoctorName], [About], [ClinicID]) VALUES (4, N'Amir ', N'Second Class', 1)
GO
SET IDENTITY_INSERT [dbo].[TBLDoctors] OFF
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (0, N'Sunday')
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (1, N'Monday')
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (2, N'Tuesday')
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (3, N'Wednesday')
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (4, N'Thursday')
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (5, N'Friday')
GO
INSERT [dbo].[WeekDays] ([Id], [Day]) VALUES (6, N'Saturday')
GO
SET IDENTITY_INSERT [dbo].[TBLDoctorSchedule] ON 
GO
INSERT [dbo].[TBLDoctorSchedule] ([ScheduleID], [DoctorID], [DayOfWeek], [StartTime], [EndTime], [PatientName], [PatientAge], [Date]) VALUES (6, 3, 0, CAST(N'01:00:00' AS Time), CAST(N'01:30:00' AS Time), N'Awd', 19, CAST(N'2023-09-17' AS Date))
GO
INSERT [dbo].[TBLDoctorSchedule] ([ScheduleID], [DoctorID], [DayOfWeek], [StartTime], [EndTime], [PatientName], [PatientAge], [Date]) VALUES (8, 3, 0, CAST(N'02:00:00' AS Time), CAST(N'02:30:00' AS Time), N'Saad', 21, CAST(N'2023-09-17' AS Date))
GO
INSERT [dbo].[TBLDoctorSchedule] ([ScheduleID], [DoctorID], [DayOfWeek], [StartTime], [EndTime], [PatientName], [PatientAge], [Date]) VALUES (9, 3, 0, CAST(N'01:00:00' AS Time), CAST(N'01:30:00' AS Time), N'Ark', 22, CAST(N'2023-09-24' AS Date))
GO
INSERT [dbo].[TBLDoctorSchedule] ([ScheduleID], [DoctorID], [DayOfWeek], [StartTime], [EndTime], [PatientName], [PatientAge], [Date]) VALUES (10, 4, 0, CAST(N'02:00:00' AS Time), CAST(N'02:30:00' AS Time), N'Saad', 22, CAST(N'2023-09-17' AS Date))
GO
INSERT [dbo].[TBLDoctorSchedule] ([ScheduleID], [DoctorID], [DayOfWeek], [StartTime], [EndTime], [PatientName], [PatientAge], [Date]) VALUES (11, 4, 0, CAST(N'23:00:00' AS Time), CAST(N'23:30:00' AS Time), N'Sara', 33, CAST(N'2023-09-17' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TBLDoctorSchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[DoctorWorkDays] ON 
GO
INSERT [dbo].[DoctorWorkDays] ([Id], [DayId], [DoctorID]) VALUES (11, 0, 3)
GO
INSERT [dbo].[DoctorWorkDays] ([Id], [DayId], [DoctorID]) VALUES (12, 0, 4)
GO
INSERT [dbo].[DoctorWorkDays] ([Id], [DayId], [DoctorID]) VALUES (13, 1, 3)
GO
INSERT [dbo].[DoctorWorkDays] ([Id], [DayId], [DoctorID]) VALUES (14, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[DoctorWorkDays] OFF
GO
