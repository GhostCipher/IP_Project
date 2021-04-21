CREATE TABLE [dbo].[Table] (
    [Id]        INT  NOT NULL,
    [Name]      TEXT NOT NULL,
    [Admin]     INT  DEFAULT ((0)) NOT NULL,
    [Moderator] INT  DEFAULT ((0)) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

