
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/27/2015 21:08:49
-- Generated from EDMX file: C:\Users\Administrator\Desktop\wbmForEF-master\BM.Models\civilization.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [civilization];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tb_error]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_error];
GO
IF OBJECT_ID(N'[dbo].[tb_OperateLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_OperateLog];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tb_error'
CREATE TABLE [dbo].[tb_error] (
    [ID] varchar(50)  NOT NULL,
    [ErrorName] varchar(50)  NOT NULL,
    [ErrorMessage] varchar(max)  NOT NULL,
    [ErrorDate] datetime  NOT NULL,
    [ErrorAction] varchar(50)  NOT NULL
);
GO

-- Creating table 'tb_OperateLog'
CREATE TABLE [dbo].[tb_OperateLog] (
    [ID] nvarchar(50)  NOT NULL,
    [IP] nvarchar(12)  NOT NULL,
    [OperateType] int  NOT NULL,
    [DateTime] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'tb_error'
ALTER TABLE [dbo].[tb_error]
ADD CONSTRAINT [PK_tb_error]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tb_OperateLog'
ALTER TABLE [dbo].[tb_OperateLog]
ADD CONSTRAINT [PK_tb_OperateLog]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------