CREATE PROCEDURE [dbo].[GetLists]
	@username VARCHAR(50)
AS
	DECLARE @userID INT
	EXEC GetUserID @username, @userID OUT

	SELECT
		L.Name
	FROM
		Lists L
	WHERE
		L.Owner = @userID
RETURN 0