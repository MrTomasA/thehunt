CREATE TABLE [dbo].[BusinessStream]
(
	[Id] INT NOT NULL IDENTITY , 
    [BusinessStreamName] VARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_BusinessStream] PRIMARY KEY ([Id])
)
