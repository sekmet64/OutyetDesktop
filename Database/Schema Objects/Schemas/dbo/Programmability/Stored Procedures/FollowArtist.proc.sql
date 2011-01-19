CREATE PROCEDURE [dbo].[FollowArtist]
	@username VARCHAR(50),
	@person VARCHAR(50)
AS
	DECLARE @userID INT;
	EXEC GetUserID @username, @userID OUT;

	DECLARE @personID INT;
	SET @personID = -1;
	
	EXEC @personID = GetPersonID @person;
	IF @personID = -1
		RETURN -1
	ELSE
	BEGIN
		INSERT INTO
			Follows
		VALUES
			(@userID, @personID)
		RETURN 1;
	END
