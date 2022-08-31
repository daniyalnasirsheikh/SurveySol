CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[SurveyResponseProfileId] INT NOT NULL, 
	[QuestionId] INT NOT NULL,
    [AnswerText] NVARCHAR(MAX) NULL,

	[DocPath] VARCHAR(MAX) NULL, 
    CONSTRAINT FK_SurveyResponseProfile_Answer FOREIGN KEY ([SurveyResponseProfileId]) REFERENCES [SurveyResponseProfile] (Id) ON DELETE CASCADE,
    CONSTRAINT FK_Question_Answer FOREIGN KEY (QuestionId) REFERENCES Question (Id) ON DELETE CASCADE
)
