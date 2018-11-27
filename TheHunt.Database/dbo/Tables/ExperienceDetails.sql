CREATE TABLE [dbo].[ExperienceDetails]
(
	[UserAccountId] INT NOT NULL , 
    [IsCurrentJob] BIT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [JobTitle] VARCHAR(50) NOT NULL, 
    [CompanyName] VARCHAR(100) NOT NULL, 
    [JobLocationCity] VARCHAR(50) NOT NULL, 
    [JobLocationState] VARCHAR(50) NOT NULL, 
    [JobLocationCountry] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    PRIMARY KEY ([UserAccountId], [StartDate], [EndDate]), 
    CONSTRAINT [FK_ExperienceDetails_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
)
