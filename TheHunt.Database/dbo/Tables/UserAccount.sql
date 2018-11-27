CREATE TABLE [dbo].[UserAccount]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserTypeId] INT NOT NULL, 
    [Email] VARCHAR(255) NOT NULL, 
    [DateOfBirth] DATETIME NULL, 
    [Gender] VARCHAR NULL, 
    [IsActive] BIT NOT NULL, 
    [ContactNumber] VARCHAR(10) NULL, 
    [EmailNotificationActive] BIT NULL, 
    [RegistrationDate] DATETIME NOT NULL,
	CONSTRAINT [PK_UserAccount_Id] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_UserAccount_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [UserType]([Id])
)
