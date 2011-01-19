CREATE PROCEDURE [dbo].[GetUserRank]
	@username VARCHAR(50)
AS
	DECLARE @rank INT;
	SELECT
		@rank = U.[Rank]
	FROM
		Users U
	WHERE
		U.Username = @username
RETURN @rank