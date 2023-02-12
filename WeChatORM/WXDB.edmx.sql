
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/11/2023 10:55:03
-- Generated from EDMX file: E:\Project\WeChat\WeChatORM\WXDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bds272082693_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Global_Error]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Global_Error];
GO
IF OBJECT_ID(N'[dbo].[JokeDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JokeDetail];
GO
IF OBJECT_ID(N'[dbo].[WX_Access_token]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WX_Access_token];
GO
IF OBJECT_ID(N'[dbo].[WX_RequestMsgLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WX_RequestMsgLog];
GO
IF OBJECT_ID(N'[dbo].[WX_RequestParserFail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WX_RequestParserFail];
GO
IF OBJECT_ID(N'[dbo].[WX_ResponseMsgLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WX_ResponseMsgLog];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Global_Error'
CREATE TABLE [dbo].[Global_Error] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] varchar(max)  NULL,
    [CreateDate] datetime  NOT NULL
);
GO

-- Creating table 'WX_RequestParserFail'
CREATE TABLE [dbo].[WX_RequestParserFail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestXML] varchar(max)  NULL,
    [RequestJson] varchar(max)  NULL,
    [CreateDate] datetime  NOT NULL
);
GO

-- Creating table 'WX_ResponseMsgLog'
CREATE TABLE [dbo].[WX_ResponseMsgLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestId] int  NOT NULL,
    [ToUserName] varchar(100)  NULL,
    [FromUserName] varchar(100)  NULL,
    [CreateTime] varchar(100)  NULL,
    [MsgType] varchar(100)  NULL,
    [ResponseXML] varchar(max)  NULL,
    [CreateDate] datetime  NOT NULL
);
GO

-- Creating table 'WX_RequestMsgLog'
CREATE TABLE [dbo].[WX_RequestMsgLog] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ToUserName] varchar(100)  NULL,
    [FromUserName] varchar(100)  NULL,
    [CreateTime] varchar(100)  NULL,
    [MsgType] varchar(100)  NULL,
    [MsgId] varchar(100)  NULL,
    [RequestJson] varchar(max)  NULL,
    [RequestXML] varchar(max)  NULL,
    [CreateDate] datetime  NOT NULL
);
GO

-- Creating table 'JokeDetail'
CREATE TABLE [dbo].[JokeDetail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormId] int  NOT NULL,
    [Author] nvarchar(30)  NULL,
    [PublishDate] datetime  NOT NULL,
    [Content] nvarchar(max)  NULL,
    [ImgUrl] varchar(500)  NULL,
    [Tag] varchar(10)  NOT NULL,
    [GoodNum] int  NOT NULL,
    [ReplyNum] int  NOT NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'WX_Access_token'
CREATE TABLE [dbo].[WX_Access_token] (
    [access_token] varchar(1000)  NOT NULL,
    [updatedate] datetime  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Global_Error'
ALTER TABLE [dbo].[Global_Error]
ADD CONSTRAINT [PK_Global_Error]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WX_RequestParserFail'
ALTER TABLE [dbo].[WX_RequestParserFail]
ADD CONSTRAINT [PK_WX_RequestParserFail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WX_ResponseMsgLog'
ALTER TABLE [dbo].[WX_ResponseMsgLog]
ADD CONSTRAINT [PK_WX_ResponseMsgLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WX_RequestMsgLog'
ALTER TABLE [dbo].[WX_RequestMsgLog]
ADD CONSTRAINT [PK_WX_RequestMsgLog]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JokeDetail'
ALTER TABLE [dbo].[JokeDetail]
ADD CONSTRAINT [PK_JokeDetail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'WX_Access_token'
ALTER TABLE [dbo].[WX_Access_token]
ADD CONSTRAINT [PK_WX_Access_token]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------