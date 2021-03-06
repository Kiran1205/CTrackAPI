use  master
go
drop database ctrack
go

CREATE DATABASE CTrack
GO

USE CTrack
GO

--Tables

--[dbo].[User]
CREATE TABLE [dbo].[User] (

	UserPID BIGINT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NULL,
	[Password] NVARCHAR(50) NULL,
	PhoneNumber BIGINT NULL,
	PinNumber BIGINT NULL,
	DeviseInfo VARCHAR(256) NULL,
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL	
)

GO

--PK_User
ALTER TABLE [dbo].[User]
	ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserPID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

--IX_USER_PHONENUMBER
CREATE UNIQUE NONCLUSTERED INDEX [IX_USER_PHONENUMBER]
ON [dbo].[User]
(
	[PhoneNumber] ASC
) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)ON [PRIMARY]

--[UQ_PhoneNumber]
--ALTER TABLE [dbo].[User]
--	ADD CONSTRAINT [UQ_PhoneNumber] UNIQUE ([PhoneNumber])

--[dbo].[Roles]
CREATE TABLE [dbo].[Roles] (

	RolesPID bigint IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NULL,
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL

)

GO

--PK_Roles
ALTER TABLE [dbo].[Roles]
	ADD CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RolesPID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

SET IDENTITY_INSERT [dbo].[Roles] on

INSERT INTO [dbo].[Roles] (RolesPID,Name) VALUES(1,'Admin')
INSERT INTO [dbo].[Roles] (RolesPID,Name) VALUES(2,'Self')

SET IDENTITY_INSERT [dbo].[Roles] off

GO

--[dbo].[Chitti]
CREATE TABLE [dbo].[Chitti] (

	ChittiPID BIGINT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NULL,
	Amount MONEY NULL,
	Commission MONEY NULL,
	NoOfMonths INT NULL,
	StartDate DATE NULL,
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_Chitti
ALTER TABLE [dbo].[Chitti]
	ADD CONSTRAINT [PK_Chitti] PRIMARY KEY CLUSTERED ([ChittiPID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

--[dbo].[People]
CREATE TABLE [dbo].[People] (

	PeoplePID BIGINT IDENTITY(1,1) NOT NULL,
	Name varchar(50) NULL,
	PhoneNumber BIGINT NULL,
	ChittiPID BIGINT NULL,
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_People
ALTER TABLE [dbo].[People]
	ADD CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED (PeoplePID ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

	
--FK_People_Chitti
--ALTER TABLE [dbo].[People]
--	ADD CONSTRAINT [FK_People_Chitti] FOREIGN KEY ([ChittiPID]) REFERENCES [dbo].[Chitti]([ChittiPID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO


--[dbo].[PaymentTaken]
CREATE TABLE [dbo].[PaymentTaken] (

	PaymentTakenPID BIGINT IDENTITY(1,1) NOT NULL,
	PeoplePID BIGINT NULL,
	ChittiPID BIGINT NULL,
	[MonthDate] Date NULL,
	Amount MONEY NULL,	
	AuctionAmount MONEY NULL,	
	BasicAmount MONEY NULL,		
	AmountByPeople MONEY NULL,
	CommissionAmount MONEY NULL,
	MonthNumber int null,	
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_PaymentTaken
ALTER TABLE [dbo].[PaymentTaken]
	ADD CONSTRAINT [PK_PaymentTaken] PRIMARY KEY CLUSTERED (PaymentTakenPID ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

--FK_PaymentTaken_People
--ALTER TABLE [dbo].[PaymentTaken]
--	ADD CONSTRAINT [FK_PaymentTaken_People] FOREIGN KEY ([PeoplePID]) REFERENCES [dbo].[People]([PeoplePID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO
	
--FK_PaymentTaken_Chitti
--ALTER TABLE [dbo].[PaymentTaken]
--	ADD CONSTRAINT [FK_PaymentTaken_Chitti] FOREIGN KEY ([ChittiPID]) REFERENCES [dbo].[Chitti]([ChittiPID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO


--[dbo].[Permission]
CREATE TABLE [dbo].[Permission] (

	PermissionPID BIGINT IDENTITY(1,1) NOT NULL,
	ChittiPID BIGINT NULL,
	UserPID BIGINT NULL,
	RolePID BIGINT NULL,
	PeoplePID BIGINT NULL,	
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_Permission
ALTER TABLE [dbo].[Permission]
	ADD CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED (PermissionPID ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

	
--FK_Permission_Chitti
--ALTER TABLE [dbo].[Permission]
--	ADD CONSTRAINT [FK_Permission_Chitti] FOREIGN KEY ([ChittiPID]) REFERENCES [dbo].[Chitti]([ChittiPID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO

--FK_Permission_NotificationType
--ALTER TABLE [dbo].[Permission]
--	ADD CONSTRAINT [FK_Permission_Role] FOREIGN KEY ([RolePID]) REFERENCES [dbo].[Role]([RolePID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO

--[dbo].[NotificationType]
CREATE TABLE [dbo].[NotificationType] (

	NotificationTypePID BIGINT IDENTITY(1,1) NOT NULL,
	[Type] VARCHAR(50) NULL,
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_NotificationType
ALTER TABLE [dbo].[NotificationType]
	ADD CONSTRAINT [PK_NotificationType] PRIMARY KEY CLUSTERED ([NotificationTypePID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

SET IDENTITY_INSERT [dbo].[NotificationType] ON

INSERT INTO [dbo].[NotificationType] (NotificationTypePID,[Type],CreatedBy) VALUES(1,'SendConformation',1/*System*/)
INSERT INTO [dbo].[NotificationType] (NotificationTypePID,[Type],CreatedBy) VALUES(2,'Conformed',1/*System*/)

SET IDENTITY_INSERT [dbo].[NotificationType] OFF

GO


--[dbo].[PaymentPaid]
CREATE TABLE [dbo].[PaymentPaid] (

	PaymentPaidPID BIGINT IDENTITY(1,1) NOT NULL,
	PeoplePID BIGINT  NULL,
	ChittiPID BIGINT NULL,
	PaidAmount MONEY NULL,
	PaidDate DATETIME NULL,
	Comments VARCHAR(256)  NULL,
	NotificationTypePID BIGINT NULL,	
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_PaymentPaid
ALTER TABLE [dbo].[PaymentPaid]
	ADD CONSTRAINT [PK_PaymentPaid] PRIMARY KEY CLUSTERED (PaymentPaidPID ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

--FK_PaymentPaid_People
--ALTER TABLE [dbo].[PaymentPaid]
--	ADD CONSTRAINT [FK_PaymentPaid_People] FOREIGN KEY ([PeoplePID]) REFERENCES [dbo].[People]([People]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO

	
--FK_PaymentPaid_Chitti
--ALTER TABLE [dbo].[PaymentPaid]
--	ADD CONSTRAINT [FK_PaymentPaid_Chitti] FOREIGN KEY ([ChittiPID]) REFERENCES [dbo].[Chitti]([ChittiPID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO

--FK_PaymentPaid_NotificationType
--ALTER TABLE [dbo].[PaymentPaid]
--	ADD CONSTRAINT [FK_PaymentPaid_NotificationType] FOREIGN KEY ([NotificationTypePID]) REFERENCES [dbo].[NotificationType]([NotificationTypePID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO


--[dbo].[Payments]
CREATE TABLE [dbo].[Payments] (

	PaymentsPID BIGINT IDENTITY(1,1) NOT NULL,
	PeoplePID BIGINT  NULL,
	[Month]  INT NULL,
	Amount MONEY NULL,
	ChittiPID BIGINT NULL,
	CreatedOn DATETIME NULL DEFAULT GETDATE(),
	UpdatedOn DATETIME NULL,
	CreatedBy BIGINT NULL,
	UpdatedBy BIGINT NULL
)

GO

--PK_Payments
ALTER TABLE [dbo].[Payments]
	ADD CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED (PaymentsPID ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY= OFF, STATISTICS_NORECOMPUTE = OFF)

GO

--FK_Payments_People
--ALTER TABLE [dbo].[Payments]
--	ADD CONSTRAINT [FK_Payments_People] FOREIGN KEY ([PeoplePID]) REFERENCES [dbo].[People] ([People]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO

	
--FK_Payments_Chitti
--ALTER TABLE [dbo].[Payments]
--	ADD CONSTRAINT [FK_Payments_Chitti] FOREIGN KEY ([ChittiPID]) REFERENCES [dbo].[Chitti] ([ChittiPID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

GO

