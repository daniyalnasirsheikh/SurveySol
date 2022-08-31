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
/*
The column [dbo].[SurveyResponseProfile].[SurveyId] on table [dbo].[SurveyResponseProfile] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[SurveyResponseProfile])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key fc4181fc-0597-4787-b9bb-0d1ce57886bd is skipped, element [dbo].[Student].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key a530b019-1f1b-480c-9898-afcd451bfe01 is skipped, element [dbo].[SurveyResponseProfile].[Name] (SqlSimpleColumn) will not be renamed to Full Name';


GO
PRINT N'Rename refactoring operation with key b54c477a-fff9-4356-80a6-dbcbae00b347 is skipped, element [dbo].[Survey].[StardDate] (SqlSimpleColumn) will not be renamed to StartDate';


GO
PRINT N'Dropping [dbo].[FK_SurveyQuestion]...';


GO
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_SurveyQuestion];


GO
PRINT N'Dropping [dbo].[FK_AspNetUserUserShareSurvey]...';


GO
ALTER TABLE [dbo].[UserShareSurvey] DROP CONSTRAINT [FK_AspNetUserUserShareSurvey];


GO
PRINT N'Dropping [dbo].[FK_SurveyUserShareSurvey]...';


GO
ALTER TABLE [dbo].[UserShareSurvey] DROP CONSTRAINT [FK_SurveyUserShareSurvey];


GO
PRINT N'Dropping [dbo].[UC_UserSurvey]...';


GO
ALTER TABLE [dbo].[UserShareSurvey] DROP CONSTRAINT [UC_UserSurvey];


GO
PRINT N'Starting rebuilding table [dbo].[SurveyResponseProfile]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_SurveyResponseProfile] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [SurveyId]   INT           NOT NULL,
    [Full Name]  VARCHAR (100) NOT NULL,
    [ResponseOn] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[SurveyResponseProfile])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_SurveyResponseProfile] ON;
        INSERT INTO [dbo].[tmp_ms_xx_SurveyResponseProfile] ([Id], [Full Name], [ResponseOn])
        SELECT   [Id],
                 [Full Name],
                 [ResponseOn]
        FROM     [dbo].[SurveyResponseProfile]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_SurveyResponseProfile] OFF;
    END

DROP TABLE [dbo].[SurveyResponseProfile];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_SurveyResponseProfile]', N'SurveyResponseProfile';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Answer]...';


GO
CREATE TABLE [dbo].[Answer] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [SurveyResponseProfileId] INT            NOT NULL,
    [QuestionId]              INT            NOT NULL,
    [AnswerText]              NVARCHAR (256) NOT NULL,
    [DocPath]                 VARCHAR (256)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[UC_User_Survey]...';


GO
ALTER TABLE [dbo].[UserShareSurvey]
    ADD CONSTRAINT [UC_User_Survey] UNIQUE NONCLUSTERED ([UserId] ASC, [SurveyId] ASC);


GO
PRINT N'Creating [dbo].[FK_SurveyResponseProfile_Answer]...';


GO
ALTER TABLE [dbo].[Answer] WITH NOCHECK
    ADD CONSTRAINT [FK_SurveyResponseProfile_Answer] FOREIGN KEY ([SurveyResponseProfileId]) REFERENCES [dbo].[SurveyResponseProfile] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_Question_Answer]...';


GO
ALTER TABLE [dbo].[Answer] WITH NOCHECK
    ADD CONSTRAINT [FK_Question_Answer] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_Survey_Question]...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD CONSTRAINT [FK_Survey_Question] FOREIGN KEY ([SurveyId]) REFERENCES [dbo].[Survey] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_AspNetUserUserShare_Survey]...';


GO
ALTER TABLE [dbo].[UserShareSurvey] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUserUserShare_Survey] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SurveyUserShare_Survey]...';


GO
ALTER TABLE [dbo].[UserShareSurvey] WITH NOCHECK
    ADD CONSTRAINT [FK_SurveyUserShare_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [dbo].[Survey] ([Id]) ON DELETE CASCADE;


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'fc4181fc-0597-4787-b9bb-0d1ce57886bd')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('fc4181fc-0597-4787-b9bb-0d1ce57886bd')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a530b019-1f1b-480c-9898-afcd451bfe01')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a530b019-1f1b-480c-9898-afcd451bfe01')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b54c477a-fff9-4356-80a6-dbcbae00b347')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b54c477a-fff9-4356-80a6-dbcbae00b347')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Answer] WITH CHECK CHECK CONSTRAINT [FK_SurveyResponseProfile_Answer];

ALTER TABLE [dbo].[Answer] WITH CHECK CHECK CONSTRAINT [FK_Question_Answer];

ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_Survey_Question];

ALTER TABLE [dbo].[UserShareSurvey] WITH CHECK CHECK CONSTRAINT [FK_AspNetUserUserShare_Survey];

ALTER TABLE [dbo].[UserShareSurvey] WITH CHECK CHECK CONSTRAINT [FK_SurveyUserShare_Survey];


GO
PRINT N'Update complete.';


GO
