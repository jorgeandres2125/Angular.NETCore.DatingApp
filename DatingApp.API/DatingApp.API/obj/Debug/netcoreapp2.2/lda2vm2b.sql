IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Values] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Values] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200418004213_InitialCreate', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Users] ADD [City] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [Country] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [Created] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [DateOfBirth] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [Gender] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [Interest] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [Introduction] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [KnownAs] nvarchar(max) NULL;

GO

ALTER TABLE [Users] ADD [LastActive] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Users] ADD [LookingFor] nvarchar(max) NULL;

GO

CREATE TABLE [Photos] (
    [Id] int NOT NULL IDENTITY,
    [Url] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [DateAdded] datetime2 NOT NULL,
    [IsMain] bit NOT NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Photos_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Photos_UserId] ON [Photos] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200422034448_ExtendedUserClass', N'2.2.6-servicing-10079');

GO

