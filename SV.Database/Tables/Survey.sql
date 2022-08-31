CREATE TABLE [dbo].[Survey](
	[Id] [int] NOT NULL IDENTITY,
	[UserId] [nvarchar](450) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[LogoPath] VARCHAR(256) NULL, 
    [BannerPath] VARCHAR(256) NULL, 
    [BackgroundImagePath] VARCHAR(256) NULL, 
    [MaxResponse] INT NULL, 
    [QuestionPerPage] INT NULL, 
	[IsLaunched] [bit] NOT NULL,
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    CONSTRAINT [PK__Survey__3214EC076FDE4AC7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Survey]  WITH CHECK ADD  CONSTRAINT [FK_Survey_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Survey] CHECK CONSTRAINT [FK_Survey_AspNetUsers]
GO


