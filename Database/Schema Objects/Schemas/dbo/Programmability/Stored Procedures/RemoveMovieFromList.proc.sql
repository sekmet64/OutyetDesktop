CREATE PROCEDURE [dbo].[RemoveMovieFromList]
	@username VARCHAR(50),
	@list VARChAR(50),
	@movieID INT
AS
	DECLARE @userID INT;
	EXEC GetUserID @username, @userID OUT;

	DECLARE @listID INT;
	EXEC GetListID @userID, @list, @listID OUT;

	DELETE FROM
		ListEntries
	WHERE
		List = @listID AND
		Movie = @movieID


	
RETURN 0