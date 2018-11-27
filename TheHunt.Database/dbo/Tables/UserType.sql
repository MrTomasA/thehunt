CREATE TABLE [dbo].[UserType] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [UserTypeName] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_UserType_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

