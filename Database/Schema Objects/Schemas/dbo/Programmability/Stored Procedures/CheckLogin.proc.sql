CREATE PROCEDURE [dbo].[CheckLogin]
	@username VARCHAR(50),
	@password VARCHAR(50)
AS
	DECLARE @rows INT;
	SET @rows = (
		SELECT
			COUNT(*)
		FROM 
			Users U
		WHERE
			U.Username = @username AND
			U.Password = HASHBYTES('SHA1', @password))
RETURN @rows