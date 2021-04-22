CREATE PROCEDURE [dbo].[GetRole]
	@name text
AS
	begin
		declare @role int
		select @role = Admin + Moderator 
		from Users 
		where Name = @name
	end
