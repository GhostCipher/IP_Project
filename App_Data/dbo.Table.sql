CREATE TABLE [dbo].[Users]
(
    [Name] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Role] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Email])
)