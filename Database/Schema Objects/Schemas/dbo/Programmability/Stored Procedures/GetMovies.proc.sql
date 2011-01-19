CREATE PROCEDURE [dbo].[GetMovies]
AS
	SELECT
		M.ID, M.Title, M.[Year]
	FROM
		Movies M
RETURN 0