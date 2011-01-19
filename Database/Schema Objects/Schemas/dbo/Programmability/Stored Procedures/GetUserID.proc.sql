CREATE PROCEDURE [dbo].[GetUserID]
	@username varchar(50),
	@userID int OUT
AS
	SELECT 
		@userID = U.ID
	FROM
		Users U
	WHERE
		U.Username = @username
RETURN 0