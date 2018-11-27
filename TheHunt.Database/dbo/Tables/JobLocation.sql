CREATE TABLE [dbo].[JobLocation]
(
	[Id] INT NOT NULL IDENTITY, 
    [StreetAddress] VARCHAR(100) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [Country] VARCHAR(50) NOT NULL, 
    [Zip] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_JobLocation] PRIMARY KEY ([Id]) 
)
