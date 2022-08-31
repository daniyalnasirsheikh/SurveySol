CREATE TABLE [dbo].[SurveyResponseProfile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SurveyId] INT NOT NULL,
    [Full Name] VARCHAR(100) NOT NULL, 
    [ResponseOn] DATETIME NOT NULL, 
)
