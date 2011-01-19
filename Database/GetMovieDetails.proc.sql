CREATE PROCEDURE [dbo].[GetMovieDetails]
	@movieID INT
AS
	SELECT
		M.Title, M.[Year], M.ReleaseDate
	FROM
		Movies M
	WHERE
		M.ID = @movieID
RETURN 0