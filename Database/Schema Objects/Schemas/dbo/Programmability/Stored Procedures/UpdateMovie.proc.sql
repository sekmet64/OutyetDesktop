CREATE PROCEDURE [dbo].[UpdateMovie]
	@movieID INT,
	@title VARCHAR(50),
	@year INT,
	@releaseDate DATE
AS
	UPDATE
		Movies
	SET
		Title = @title,
		[Year] = @year,
		ReleaseDate = @releaseDate
	WHERE
		ID = @movieID
RETURN 0