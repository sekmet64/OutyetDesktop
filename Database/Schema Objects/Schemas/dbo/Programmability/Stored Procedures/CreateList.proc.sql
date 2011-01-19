CREATE PROCEDURE [dbo].[CreateList]
	@username VARCHAR(50),
	@list VARCHAR(50)
AS
	DECLARE @userID INT;
	EXEC GetUserID @username, @userID OUT;

	DECLARE @exists INT;
	
	SELECT
		@exists = COUNT(*)
	FROM
		Lists L
	WHERE
		L.Name = @list AND
		L.[Owner] = @userID

	IF @exists = 1
		RETURN -1
	ELSE
	BEGIN
		INSERT INTO
			Lists (Name, [Owner])
		VALUES
			(@list, @userID)
	END
		
RETURN 1