CREATE TABLE [dbo].[EmailTemplate]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SenderName] NVARCHAR(60) NULL, 
    [Subject] NVARCHAR(256) NULL, 
    [Body] NVARCHAR(MAX) NULL
)
