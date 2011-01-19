CREATE PROCEDURE [dbo].[AddWriterToMovie]
	@writer VARCHAR(50),
	@movieID INT
AS
	DECLARE @personID INT;
	EXEC @personID = GetOrAddPersonID @writer;
	
	INSERT INTO
		Writes (PersonID, MovieID)
	VALUES
		(@personID, @movieID)