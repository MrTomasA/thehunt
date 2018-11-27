CREATE TABLE [dbo].[JobPost]
(
	[Id] INT NOT NULL IDENTITY , 
    [PostedById] INT NOT NULL, 
    [JobTypeId] INT NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [IsCompanyNameHidden] BIT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [JobDescription] VARCHAR(1000) NOT NULL, 
    [JobLocationId] INT NOT NULL, 
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [PK_JobPost] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_JobPost_Company] FOREIGN KEY (CompanyId) REFERENCES [Company]([Id]), 
    CONSTRAINT [FK_JobPost_JobType] FOREIGN KEY ([JobTypeId]) REFERENCES [JobType]([Id]), 
    CONSTRAINT [FK_JobPost_UserAccount] FOREIGN KEY ([PostedById]) REFERENCES [UserAccount]([Id]), 
    CONSTRAINT [FK_JobPost_JobLocation] FOREIGN KEY ([JobLocationId]) REFERENCES [JobLocation]([Id])
)
