CREATE PROCEDURE [dbo].[AddActorToMovie]
	@actor VARCHAR(50),
	@movieID INT
AS
	DECLARE @personID INT;
	EXEC @personID = GetOrAddPersonID @actor;
	
	INSERT INTO
		Acts (PersonID, MovieID)
	VALUES
		(@personID, @movieID)