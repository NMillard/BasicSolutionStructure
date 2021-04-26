IF OBJECT_ID(N'[App].[_EFMigrationsHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'App') IS NULL EXEC(N'CREATE SCHEMA [App];');
    CREATE TABLE [App].[_EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK__EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [App].[_EFMigrationsHistory] WHERE [MigrationId] = N'20210426113343_Initial')
BEGIN
    IF SCHEMA_ID(N'App') IS NULL EXEC(N'CREATE SCHEMA [App];');
END;
GO

IF NOT EXISTS(SELECT * FROM [App].[_EFMigrationsHistory] WHERE [MigrationId] = N'20210426113343_Initial')
BEGIN
    CREATE TABLE [App].[Users] (
        [Id] uniqueidentifier NOT NULL,
        [Username] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [App].[_EFMigrationsHistory] WHERE [MigrationId] = N'20210426113343_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Users_Username] ON [App].[Users] ([Username]);
END;
GO

IF NOT EXISTS(SELECT * FROM [App].[_EFMigrationsHistory] WHERE [MigrationId] = N'20210426113343_Initial')
BEGIN
    INSERT INTO [App].[_EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210426113343_Initial', N'5.0.5');
END;
GO

COMMIT;
GO

