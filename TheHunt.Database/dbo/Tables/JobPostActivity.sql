CREATE TABLE [dbo].[JobPostActivity]
(
	[UserAccountId] INT NOT NULL, 
    [JostPostId] INT NOT NULL, 
    [ApplyDate] DATETIME NULL,
	CONSTRAINT [PK_JobPostActivity_UserAccountId] PRIMARY KEY CLUSTERED ([UserAccountId], [JostPostId]),
	CONSTRAINT [FK_JobPostActivity_UserAccountId] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id]) 
)
