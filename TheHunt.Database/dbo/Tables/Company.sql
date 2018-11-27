CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL IDENTITY , 
    [CompanyName] VARCHAR(100) NOT NULL, 
    [ProfileDescription] VARCHAR(1000) NOT NULL, 
    [BusinessStreamId] INT NOT NULL, 
    [EstablishmentDate] DATETIME NULL, 
    [CompanyWebsiteUrl] VARCHAR(500) NULL, 
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Company_BusinessStream] FOREIGN KEY ([BusinessStreamId]) REFERENCES [BusinessStream]([Id])
)
