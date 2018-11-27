CREATE TABLE [dbo].[JobPostSkillSet]
(
	[SkillSetId] INT NOT NULL , 
    [JobPostId] INT NOT NULL, 
    [SkillLevel] INT NULL, 
    CONSTRAINT [PK_JobPostSkillSet] PRIMARY KEY ([SkillSetId], [JobPostId])
)
