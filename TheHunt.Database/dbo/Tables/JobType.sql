﻿CREATE TABLE [dbo].[JobType]
(
	[Id] INT NOT NULL IDENTITY , 
    [Name] VARCHAR(20) NOT NULL, 
    CONSTRAINT [PK_JobType] PRIMARY KEY ([Id])
)
