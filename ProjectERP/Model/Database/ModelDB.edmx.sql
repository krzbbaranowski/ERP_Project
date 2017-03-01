
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/01/2017 14:48:29
-- Generated from EDMX file: E:\GitsRepo\ERP_Project\ProjectERP\Model\Database\ModelDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JadeDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AddressCounterparty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_AddressCounterparty];
GO
IF OBJECT_ID(N'[dbo].[FK_ProvinceAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_ProvinceAddress];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Counterparty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Counterparty];
GO
IF OBJECT_ID(N'[dbo].[Province]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Province];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Counterparty'
CREATE TABLE [dbo].[Counterparty] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name1] nvarchar(max)  NOT NULL,
    [Name2] nvarchar(max)  NOT NULL,
    [Name3] nvarchar(max)  NOT NULL,
    [NIP] nvarchar(max)  NOT NULL,
    [REGON] nvarchar(max)  NOT NULL,
    [PESEL] nvarchar(max)  NOT NULL,
    [Address_Id] int  NULL
);
GO

-- Creating table 'Province'
CREATE TABLE [dbo].[Province] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [House] int  NOT NULL,
    [Flat] int  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [Telephone2] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Fax] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Province_Id] int  NOT NULL,
    [Counterparty_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Counterparty'
ALTER TABLE [dbo].[Counterparty]
ADD CONSTRAINT [PK_Counterparty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Province'
ALTER TABLE [dbo].[Province]
ADD CONSTRAINT [PK_Province]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Province_Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [FK_ProvinceAddress]
    FOREIGN KEY ([Province_Id])
    REFERENCES [dbo].[Province]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinceAddress'
CREATE INDEX [IX_FK_ProvinceAddress]
ON [dbo].[Address]
    ([Province_Id]);
GO

-- Creating foreign key on [Address_Id] in table 'Counterparty'
ALTER TABLE [dbo].[Counterparty]
ADD CONSTRAINT [FK_CounterpartyAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CounterpartyAddress'
CREATE INDEX [IX_FK_CounterpartyAddress]
ON [dbo].[Counterparty]
    ([Address_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------