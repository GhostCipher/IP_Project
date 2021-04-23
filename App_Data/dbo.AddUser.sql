CREATE PROCEDURE [dbo].[AddUser]
	@Name nvarchar(50),
	@Password nvarchar(50),
	@Email nvarchar(50),
	@Role nvarchar(50)

AS
	INSERT INTO Users(Name, Password, Email, Role )
	Values (@Name,@Password,@Email, @Role)
RETURN 0