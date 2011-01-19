CREATE PROCEDURE [dbo].[GetOrAddPersonID]
	@name VARCHAR(50)
AS
	DECLARE @personID INT;
	SET @personID = -1;
	
	SELECT
		@personID = P.ID
	FROM
		Persons P
	WHERE
		P.Name = @name

	IF @personID = -1
	BEGIN
		INSERT INTO
			Persons (Name)
		VALUES
			(@name)

		RETURN SCOPE_IDENTITY();
	END
	ELSE
		RETURN @personID;