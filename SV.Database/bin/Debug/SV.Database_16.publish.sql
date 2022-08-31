﻿/*
Deployment script for SVDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SVDB"
:setvar DefaultFilePrefix "SVDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Dropping [dbo].[FK_Question_ToQuestion]...';


GO
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_ToQuestion];


GO
PRINT N'Dropping [dbo].[FK_Survey_Question]...';


GO
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Survey_Question];


GO
PRINT N'Dropping [dbo].[FK_Question_Answer]...';


GO
ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_Question_Answer];


GO
PRINT N'Starting rebuilding table [dbo].[Question]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Question] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [SurveyId]            INT            NOT NULL,
    [Order]               INT            NOT NULL,
    [QuestionText]        NVARCHAR (256) NOT NULL,
    [Type]                VARCHAR (50)   NOT NULL,
    [IsRequire]           BIT            NOT NULL,
    [IsDocRequire]        BIT            NOT NULL,
    [DocPath]             VARCHAR (256)  NULL,
    [OptionsText]         NVARCHAR (MAX) NULL,
    [CssClass]            VARCHAR (50)   NULL,
    [OptionsAlignment]    VARCHAR (50)   NULL,
    [LogicalQuestionText] NVARCHAR (256) NULL,
    [ParentQuestionId]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Question])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Question] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId])
        SELECT   [Id],
                 [SurveyId],
                 [Order],
                 [QuestionText],
                 [Type],
                 [IsRequire],
                 [IsDocRequire],
                 [DocPath],
                 [OptionsText],
                 [CssClass],
                 [OptionsAlignment],
                 [LogicalQuestionText],
                 [ParentQuestionId]
        FROM     [dbo].[Question]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Question] OFF;
    END

DROP TABLE [dbo].[Question];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Question]', N'Question';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[FK_Question_ToQuestion]...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD CONSTRAINT [FK_Question_ToQuestion] FOREIGN KEY ([ParentQuestionId]) REFERENCES [dbo].[Question] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Survey_Question]...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD CONSTRAINT [FK_Survey_Question] FOREIGN KEY ([SurveyId]) REFERENCES [dbo].[Survey] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_Question_Answer]...';


GO
ALTER TABLE [dbo].[Answer] WITH NOCHECK
    ADD CONSTRAINT [FK_Question_Answer] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_Question_ToQuestion];

ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_Survey_Question];

ALTER TABLE [dbo].[Answer] WITH CHECK CHECK CONSTRAINT [FK_Question_Answer];


GO
PRINT N'Update complete.';


GO
