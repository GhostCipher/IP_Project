CREATE PROCEDURE [dbo].[ValidateUser]
	@Username NVARCHAR(50),
	@Password NVARCHAR(50)
AS
	BEGIN
		SET nocount ON
		DECLARE @UserId text

		SELECT @UserId = Name
		FROM Users 
		 WHERE Email = @Username 
		 AND Password = @Password

		IF @UserId IS NOT NULL
			BEGIN
				SELECT @UserId -- User Valid
			END
		Else
			BEGIN
				SELECT null -- User invalid.
			END
	END