CREATE PROCEDURE [dbo].[AddDirectorToMovie]
	@director VARCHAR(50),
	@movieID INT
AS
	DECLARE @personID INT;
	EXEC @personID = GetOrAddPersonID @director;
	
	INSERT INTO
		Directs (PersonID, MovieID)
	VALUES
		(@personID, @movieID)