CREATE PROCEDURE [dbo].[DeleteList]
	@username VARCHAR(50),
	@list VARChAR(50)
AS
	DECLARE @userID INT;
	EXEC GetUserID @username, @userID OUT;

	DELETE FROM
		Lists
	WHERE
		Name = @list AND
		[Owner] = @userID


	
RETURN 0