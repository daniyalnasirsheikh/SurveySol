CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SurveyId] INT NOT NULL,
    [Order] INT NOT NULL,
    [QuestionText] NVARCHAR(256) NOT NULL, 
    [Type] VARCHAR(50) NOT NULL,
    [IsRequire] BIT NOT NULL,
    [IsDocRequire] BIT NOT NULL,
    [DocPath] VARCHAR(256) NULL,
    [OptionsText] NVARCHAR(MAX) NULL,
    [CssClass] VARCHAR(50) NULL, 
    [OptionsAlignment] VARCHAR(50) NULL 
    CONSTRAINT FK_Survey_Question FOREIGN KEY (SurveyId) REFERENCES Survey (Id) ON DELETE CASCADE, 
    [LogicalQuestionText] NVARCHAR(256) NULL, 
    [ParentQuestionId] INT NULL
    CONSTRAINT [FK_Question_ToQuestion] FOREIGN KEY (ParentQuestionId) REFERENCES Question(Id), 
)
