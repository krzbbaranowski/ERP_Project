
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2017 16:13:27
-- Generated from EDMX file: C:\Users\Krzysztof Baranowski\Documents\Visual Studio 2015\Projects\WpfApplication1\WpfApplication1\Model\Database\ERP_Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ERPDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CounterpartySet'
CREATE TABLE [dbo].[CounterpartySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name1] nvarchar(max)  NOT NULL,
    [Name2] nvarchar(max)  NOT NULL,
    [Name3] nvarchar(max)  NOT NULL,
    [NIP] nvarchar(max)  NOT NULL,
    [REGON] nvarchar(max)  NOT NULL,
    [PESEL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AddressSet'
CREATE TABLE [dbo].[AddressSet] (
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

-- Creating table 'ProvinceSet'
CREATE TABLE [dbo].[ProvinceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CounterpartySet'
ALTER TABLE [dbo].[CounterpartySet]
ADD CONSTRAINT [PK_CounterpartySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AddressSet'
ALTER TABLE [dbo].[AddressSet]
ADD CONSTRAINT [PK_AddressSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProvinceSet'
ALTER TABLE [dbo].[ProvinceSet]
ADD CONSTRAINT [PK_ProvinceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Province_Id] in table 'AddressSet'
ALTER TABLE [dbo].[AddressSet]
ADD CONSTRAINT [FK_ProvinceAddress]
    FOREIGN KEY ([Province_Id])
    REFERENCES [dbo].[ProvinceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinceAddress'
CREATE INDEX [IX_FK_ProvinceAddress]
ON [dbo].[AddressSet]
    ([Province_Id]);
GO

-- Creating foreign key on [Counterparty_Id] in table 'AddressSet'
ALTER TABLE [dbo].[AddressSet]
ADD CONSTRAINT [FK_AddressCounterparty]
    FOREIGN KEY ([Counterparty_Id])
    REFERENCES [dbo].[CounterpartySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressCounterparty'
CREATE INDEX [IX_FK_AddressCounterparty]
ON [dbo].[AddressSet]
    ([Counterparty_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------