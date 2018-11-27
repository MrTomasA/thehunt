CREATE TABLE [dbo].[UserLog]
(
	[UserAccountId] INT NOT NULL, 
    [LastLoginDate] DATETIME NULL, 
    [LastJobApplyDate] DATETIME NULL,
	CONSTRAINT [PK_UserLog_Id] PRIMARY KEY CLUSTERED ([UserAccountId] ASC),
	CONSTRAINT [FK_UserLog_UserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
)
