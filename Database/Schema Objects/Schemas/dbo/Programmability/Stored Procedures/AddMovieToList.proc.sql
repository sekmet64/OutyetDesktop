CREATE PROCEDURE [dbo].[AddMovieToList]
	@username VARCHAR(50), 
	@movieID INT,
	@list VARCHAR(50)
AS
	DECLARE @userID INT;
	EXEC GetUserID @username, @userID OUT;

	DECLARE @listID INT;
	EXEC GetListID @userID, @list, @listID OUT;

	DECLARE @exists INT;
	SELECT
		@exists = COUNT(*)
	FROM
		ListEntries LE
	WHERE
		LE.List = @listID AND
		LE.Movie = @movieID

	IF @exists = 1
		RETURN -1;
	ELSE 
	BEGIN
		INSERT
		INTO
			ListEntries (List, Movie)
		VALUES (@listID, @movieID)
		RETURN 1;
	END