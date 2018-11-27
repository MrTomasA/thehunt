CREATE TABLE [dbo].[TalentProfile]
(
	[UserAccountId] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [CurrentSalary] INT NULL, 
    [IsAnnuallyMonthly] BIT NULL, 
    [Currency] VARCHAR(50) NULL, 
    CONSTRAINT [FK_TalentProfile_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
)
