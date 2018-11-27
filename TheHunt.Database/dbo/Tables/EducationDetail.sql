CREATE TABLE [dbo].[EducationDetail]
(
	[UserAccountId] INT NOT NULL , 
    [CertificateDegreeName] VARCHAR(50) NOT NULL, 
    [Major] VARCHAR(50) NOT NULL, 
    [InstitueUniversityName] VARCHAR(50) NOT NULL, 
    [StartingDate] DATETIME NOT NULL, 
    [CompletionDate] DATETIME NOT NULL, 
    [Percentage] INT NULL, 
    [Gpa] DECIMAL(2, 1) NOT NULL, 
    PRIMARY KEY ([UserAccountId], [Major], [CertificateDegreeName]), 
    CONSTRAINT [FK_EducationDetail_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
)
