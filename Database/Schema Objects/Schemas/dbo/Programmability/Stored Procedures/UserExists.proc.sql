CREATE PROCEDURE [dbo].[UserExists]
	@username VARCHAR(50)
AS
IF EXISTS(SELECT * FROM	Users U	WHERE U.Username = @username)
	RETURN 1
ELSE
	RETURN 0