IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblClients] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NULL,
        [Address] nvarchar(50) NULL,
        [Phones] nvarchar(50) NULL,
        [Faxes] nvarchar(50) NULL,
        [Ceo] nvarchar(50) NULL,
        [Parent] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [WebSite] nvarchar(50) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblClients] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblConsultants] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NULL,
        [Address] nvarchar(50) NULL,
        [Phones] nvarchar(50) NULL,
        [Faxes] nvarchar(50) NULL,
        [Ceo] nvarchar(50) NULL,
        [Cofounder] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [WebSite] nvarchar(50) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblConsultants] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblContractors] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NULL,
        [Address] nvarchar(50) NULL,
        [Phones] nvarchar(50) NULL,
        [Faxes] nvarchar(50) NULL,
        [Ceo] nvarchar(50) NULL,
        [Parent] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [WebSite] nvarchar(50) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblContractors] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblRoles] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NULL,
        [Description] nvarchar(50) NULL,
        CONSTRAINT [PK_tblRoles] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblContracts] (
        [ID] int NOT NULL IDENTITY,
        [ClientID] int NULL,
        [ContractorID] int NULL,
        [ConsultantDesignID] int NULL,
        [ConsultantSupervisionID] int NULL,
        [ConsultantContractorID] int NULL,
        [Date] date NULL,
        [BaseValue] money NULL,
        [Period] int NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblContracts] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblContracts_tblClients] FOREIGN KEY ([ClientID]) REFERENCES [tblClients] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblContracts_tblConsultantsContractor] FOREIGN KEY ([ConsultantContractorID]) REFERENCES [tblConsultants] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tblContracts_tblConsultantsDesign] FOREIGN KEY ([ConsultantDesignID]) REFERENCES [tblConsultants] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblContracts_tblConsultantsSupervision] FOREIGN KEY ([ConsultantSupervisionID]) REFERENCES [tblConsultants] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tblContracts_tblContractors] FOREIGN KEY ([ContractorID]) REFERENCES [tblContractors] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblProjects] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        [Address] nvarchar(100) NULL,
        [ContractID] int NULL,
        [StartDate] date NULL,
        [FinishDate] date NULL,
        [Period] int NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblProjects] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblProjects_tblContracts] FOREIGN KEY ([ContractID]) REFERENCES [tblContracts] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblClientsTeams] (
        [ID] int NOT NULL IDENTITY,
        [ClientID] int NULL,
        [ProjectID] int NULL,
        [ResponsibleName] nvarchar(50) NULL,
        [Position] nvarchar(50) NULL,
        [StartDate] date NULL,
        [IdNo] nvarchar(50) NULL,
        [Mobile] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [Sector] nvarchar(50) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblClientsTeams] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblClientsTeams_tblClients] FOREIGN KEY ([ClientID]) REFERENCES [tblClients] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblClientsTeams_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblConsultantsTeams] (
        [ID] int NOT NULL IDENTITY,
        [ConsultantID] int NULL,
        [ProjectID] int NULL,
        [ResponsibleName] nvarchar(50) NULL,
        [Position] nvarchar(50) NULL,
        [StartDate] date NULL,
        [IdNo] nvarchar(50) NULL,
        [Mobile] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [Sector] nvarchar(50) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblConsultantsTeams] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblConsultantsTeams_tblConsultants] FOREIGN KEY ([ConsultantID]) REFERENCES [tblConsultants] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblConsultantsTeams_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblContractorsTeams] (
        [ID] int NOT NULL IDENTITY,
        [ContractorID] int NULL,
        [ProjectID] int NULL,
        [ResponsibleName] nvarchar(50) NULL,
        [Position] nvarchar(50) NULL,
        [StartDate] date NULL,
        [IdNo] nvarchar(50) NULL,
        [Mobile] nvarchar(50) NULL,
        [Email] nvarchar(50) NULL,
        [Sector] nvarchar(50) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblContractorsTeams] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblContractorsTeams_tblContractors] FOREIGN KEY ([ContractorID]) REFERENCES [tblContractors] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblContractorsTeams_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblInvoicesContractor] (
        [ID] int NOT NULL IDENTITY,
        [ProjectID] int NULL,
        [InvoiceNo] nvarchar(50) NULL,
        [Date] date NULL,
        [StoresValue] money NULL,
        [WorksUpToDate] money NULL,
        [Total] money NULL,
        [DiscountContractor] money NULL,
        [TotalAfterDiscountContractor] money NULL,
        [PreviousInvoices] money NULL,
        [InvoiceValue] money NULL,
        [PrePayed] money NULL,
        [Liability] money NULL,
        [Net] money NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblInvoicesContractor] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblInvoicesContractor_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblItems] (
        [ID] int NOT NULL IDENTITY,
        [ProjectID] int NOT NULL,
        [ItemName] nvarchar(max) NOT NULL,
        [ItemNo] nvarchar(50) NOT NULL,
        [ItemType] nvarchar(50) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_tblItems] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblItems_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblLetters] (
        [ID] int NOT NULL IDENTITY,
        [ProjectID] int NULL,
        [Date] date NULL,
        [DateReceived] date NULL,
        [IssuedBy] nvarchar(50) NULL,
        [DirectedTo] nvarchar(50) NULL,
        [Subject] nvarchar(300) NULL,
        [FilePath] nvarchar(max) NULL,
        [Descriptiopn] nvarchar(max) NULL,
        CONSTRAINT [PK_tblLetters] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblLetters_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblSchedules] (
        [ID] int NOT NULL IDENTITY,
        [Date] date NULL,
        [ScheduleNo] nvarchar(50) NULL,
        [ProjectID] int NULL,
        [SchStartDate] date NULL,
        [SchEndDate] date NULL,
        [Period] int NULL,
        [Decision] nvarchar(max) NULL,
        [DecisionDate] date NULL,
        [FilePath] nvarchar(max) NULL,
        [Remarks] nvarchar(max) NULL,
        CONSTRAINT [PK_tblSchedules] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblSchedules_tblProjects] FOREIGN KEY ([ProjectID]) REFERENCES [tblProjects] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblUsers] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NULL,
        [Password] nvarchar(50) NULL,
        [ProjectId] int NULL,
        CONSTRAINT [PK_tblUsers] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblUsers_tblProjects] FOREIGN KEY ([ProjectId]) REFERENCES [tblProjects] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [BoqViewModel] (
        [Id] int NOT NULL IDENTITY,
        [ItemId] int NULL,
        [Unit] nvarchar(max) NULL,
        [Qty] int NULL,
        [Uprice] decimal(18,2) NULL,
        [Notes] nvarchar(max) NULL,
        [ItemName] nvarchar(max) NULL,
        [ItemNo] nvarchar(max) NULL,
        [ItemType] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [ProjectId] int NOT NULL,
        CONSTRAINT [PK_BoqViewModel] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BoqViewModel_tblItems_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [tblItems] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [ItemViewModel] (
        [Id] int NOT NULL IDENTITY,
        [ProjectName] nvarchar(max) NULL,
        [ItemsId] int NULL,
        CONSTRAINT [PK_ItemViewModel] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ItemViewModel_tblItems_ItemsId] FOREIGN KEY ([ItemsId]) REFERENCES [tblItems] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblBoq] (
        [ID] int NOT NULL IDENTITY,
        [ItemID] int NOT NULL,
        [Unit] nvarchar(20) NOT NULL,
        [Qty] int NULL,
        [UPrice] money NULL,
        [Notes] nvarchar(50) NULL,
        CONSTRAINT [PK_tblBoq] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblBoq_tblItems] FOREIGN KEY ([ItemID]) REFERENCES [tblItems] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblDrawings] (
        [ID] int NOT NULL IDENTITY,
        [ItemID] int NULL,
        [DrawingName] nvarchar(50) NULL,
        [DrawingType] nvarchar(50) NULL,
        [DateIssued] date NULL,
        [DateReceived] date NULL,
        [DrawBy] nvarchar(50) NULL,
        [Receiver] nvarchar(50) NULL,
        [FilePath] nvarchar(max) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_tblDrawings] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblDrawings_tblItems] FOREIGN KEY ([ItemID]) REFERENCES [tblItems] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblSubItemsSpecifications] (
        [ID] int NOT NULL IDENTITY,
        [ItemID] int NULL,
        [SubItemName] nvarchar(50) NULL,
        [Spcifications] nvarchar(max) NULL,
        [Notes] nvarchar(50) NULL,
        CONSTRAINT [PK_tblSubItemsSpecifications] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblSubItemsSpecifications_tblItems] FOREIGN KEY ([ItemID]) REFERENCES [tblItems] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblUserRole] (
        [ID] int NOT NULL IDENTITY,
        [UserId] int NULL,
        [RoleId] int NULL,
        CONSTRAINT [PK_tblUserRole] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblUserRole_tblRoles] FOREIGN KEY ([RoleId]) REFERENCES [tblRoles] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblUserRole_tblUsers] FOREIGN KEY ([UserId]) REFERENCES [tblUsers] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblDrawingDet] (
        [ID] int NOT NULL IDENTITY,
        [DrawingID] int NULL,
        [Date] date NULL,
        [DecisionMaker] nvarchar(50) NULL,
        [Decisions] nvarchar(max) NULL,
        CONSTRAINT [PK_tblDrawingDet] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblDrawingDet_tblDrawings] FOREIGN KEY ([DrawingID]) REFERENCES [tblDrawings] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblRequests] (
        [ID] int NOT NULL IDENTITY,
        [SubItemID] int NULL,
        [Date] date NULL,
        [Subject] nvarchar(50) NULL,
        [ContractorTeamID] int NULL,
        [ConsultantTeamID] int NULL,
        [FilePath] nvarchar(max) NULL,
        [Decisions] nvarchar(max) NULL,
        CONSTRAINT [PK_tblRequests] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblRequests_tblConsultantsTeams] FOREIGN KEY ([ConsultantTeamID]) REFERENCES [tblConsultantsTeams] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tblRequests_tblContractorsTeams] FOREIGN KEY ([ContractorTeamID]) REFERENCES [tblContractorsTeams] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tblRequests_tblSubItemsSpecifications] FOREIGN KEY ([SubItemID]) REFERENCES [tblSubItemsSpecifications] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE TABLE [tblTechProposals] (
        [ID] int NOT NULL IDENTITY,
        [SubItemID] int NULL,
        [Date] date NULL,
        [ConsultantTeamID] int NULL,
        [ContractorTeamID] int NULL,
        [FilePath] nvarchar(200) NULL,
        [Provider] nvarchar(200) NULL,
        [Decesions] nvarchar(max) NULL,
        CONSTRAINT [PK_tblTechProposals] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_tblTechProposals_tblConsultantsTeams] FOREIGN KEY ([ConsultantTeamID]) REFERENCES [tblConsultantsTeams] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tblTechProposals_tblContractorsTeams] FOREIGN KEY ([ContractorTeamID]) REFERENCES [tblContractorsTeams] ([ID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_tblTechProposals_tblSubItemsSpecifications] FOREIGN KEY ([SubItemID]) REFERENCES [tblSubItemsSpecifications] ([ID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE ([NormalizedName] IS NOT NULL);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE ([NormalizedUserName] IS NOT NULL);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_BoqViewModel_ItemId] ON [BoqViewModel] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_ItemViewModel_ItemsId] ON [ItemViewModel] ([ItemsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblBoq_ItemID] ON [tblBoq] ([ItemID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblClientsTeams_ClientID] ON [tblClientsTeams] ([ClientID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblClientsTeams_ProjectID] ON [tblClientsTeams] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblConsultantsTeams_ConsultantID] ON [tblConsultantsTeams] ([ConsultantID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblConsultantsTeams_ProjectID] ON [tblConsultantsTeams] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContractorsTeams_ContractorID] ON [tblContractorsTeams] ([ContractorID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContractorsTeams_ProjectID] ON [tblContractorsTeams] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContracts_ClientID] ON [tblContracts] ([ClientID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContracts_ConsultantContractorID] ON [tblContracts] ([ConsultantContractorID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContracts_ConsultantDesignID] ON [tblContracts] ([ConsultantDesignID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContracts_ConsultantSupervisionID] ON [tblContracts] ([ConsultantSupervisionID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblContracts_ContractorID] ON [tblContracts] ([ContractorID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblDrawingDet_DrawingID] ON [tblDrawingDet] ([DrawingID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblDrawings_ItemID] ON [tblDrawings] ([ItemID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblInvoicesContractor_ProjectID] ON [tblInvoicesContractor] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblItems_ProjectID] ON [tblItems] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblLetters_ProjectID] ON [tblLetters] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblProjects_ContractID] ON [tblProjects] ([ContractID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblRequests_ConsultantTeamID] ON [tblRequests] ([ConsultantTeamID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblRequests_ContractorTeamID] ON [tblRequests] ([ContractorTeamID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblRequests_SubItemID] ON [tblRequests] ([SubItemID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblSchedules_ProjectID] ON [tblSchedules] ([ProjectID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblSubItemsSpecifications_ItemID] ON [tblSubItemsSpecifications] ([ItemID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblTechProposals_ConsultantTeamID] ON [tblTechProposals] ([ConsultantTeamID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblTechProposals_ContractorTeamID] ON [tblTechProposals] ([ContractorTeamID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblTechProposals_SubItemID] ON [tblTechProposals] ([SubItemID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblUserRole_RoleId] ON [tblUserRole] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblUserRole_UserId] ON [tblUserRole] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    CREATE INDEX [IX_tblUsers_ProjectId] ON [tblUsers] ([ProjectId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190511054023_Seeco2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190511054023_Seeco2', N'2.2.4-servicing-10062');
END;

GO

