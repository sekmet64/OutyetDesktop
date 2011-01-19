CREATE PROCEDURE [dbo].[AddMovieToDatabase]
	@title VARCHAR(50),
	@year INT,
	@releaseDate DATE
AS
	INSERT INTO
		Movies (Title, [Year], ReleaseDate)
	VALUES
		(@title, @year, @releaseDate)

RETURN SCOPE_IDENTITY()