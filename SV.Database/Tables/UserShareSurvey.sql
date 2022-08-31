CREATE TABLE [dbo].[UserShareSurvey]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(450) NOT NULL, 
    [SurveyId] INT NOT NULL,

    CONSTRAINT FK_AspNetUserUserShare_Survey FOREIGN KEY (UserId) REFERENCES [AspNetUsers](Id),
    CONSTRAINT FK_SurveyUserShare_Survey FOREIGN KEY (SurveyId) REFERENCES [Survey](Id) ON DELETE CASCADE,
    CONSTRAINT UC_User_Survey UNIQUE (UserId,SurveyId)
)
