CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NOT NULL, 
    [Admin] INT NOT NULL DEFAULT 0, 
    [Moderator] INT NOT NULL DEFAULT 0
)
