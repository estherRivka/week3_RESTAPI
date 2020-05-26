--IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
--BEGIN
--    CREATE TABLE [__EFMigrationsHistory] (
--        [MigrationId] nvarchar(150) NOT NULL,
--        [ProductVersion] nvarchar(32) NOT NULL,
--        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
--    );
--END;

--GO

CREATE TABLE [Patients] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Paths] (
    [Id] int NOT NULL IDENTITY,
    [City] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [Location] nvarchar(max) NULL,
    [PatientId] int NOT NULL,
    CONSTRAINT [PK_Paths] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Paths_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Paths_PatientId] ON [Paths] ([PatientId]);

GO

--INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
--VALUES (N'20200526075012_Init', N'3.1.4');

--GO

