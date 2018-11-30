CREATE TABLE [dbo].[TalentSkillSet]
(
	[UserAccountId] INT NOT NULL , 
    [SkillSetId] INT NOT NULL, 
    [SkillLevel] INT NOT NULL, 
    CONSTRAINT [PK_TalentSkillSet] PRIMARY KEY ([UserAccountId], [SkillSetId]), 
    CONSTRAINT [FK_TalentSkillSet_TalentProfile] FOREIGN KEY (UserAccountId) REFERENCES [TalentProfile](UserAccountId), 
    CONSTRAINT [FK_TalentSkillSet_SkillSet] FOREIGN KEY (SkillSetId) REFERENCES [SkillSet]([Id])
)
