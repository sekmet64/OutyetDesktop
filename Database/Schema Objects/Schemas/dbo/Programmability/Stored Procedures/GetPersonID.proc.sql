CREATE PROCEDURE [dbo].[GetPersonID]
	@name VARCHAR(50)
AS
	DECLARE @personID INT;
	--SET @personID = -1;
	
	SELECT
		@personID = P.ID
	FROM
		Persons P
	WHERE
		P.Name = @name
RETURN @personID