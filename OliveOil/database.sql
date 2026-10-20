IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [OliveOilProducts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Region] nvarchar(max) NOT NULL,
    [PricePerLiter] decimal(18,2) NOT NULL,
    [QuantityInStock] int NOT NULL,
    CONSTRAINT [PK_OliveOilProducts] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PricePerLiter', N'QuantityInStock', N'Region') AND [object_id] = OBJECT_ID(N'[OliveOilProducts]'))
    SET IDENTITY_INSERT [OliveOilProducts] ON;
INSERT INTO [OliveOilProducts] ([Id], [Name], [PricePerLiter], [QuantityInStock], [Region])
VALUES (1, N'nablus oil - 1', 99.0, 10, N'nablus'),
(2, N'jenin oil - 2', 99.0, 10, N'jenin'),
(3, N'hebron oil - 3', 99.0, 10, N'hebron');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PricePerLiter', N'QuantityInStock', N'Region') AND [object_id] = OBJECT_ID(N'[OliveOilProducts]'))
    SET IDENTITY_INSERT [OliveOilProducts] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261020193721_InitialCreate', N'8.0.32');
GO

COMMIT;
GO

