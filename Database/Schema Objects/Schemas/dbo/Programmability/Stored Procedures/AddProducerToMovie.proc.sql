CREATE PROCEDURE [dbo].[AddProducerToMovie]
	@producer VARCHAR(50),
	@movieID INT
AS
	DECLARE @personID INT;
	EXEC @personID = GetOrAddPersonID @producer;
	
	INSERT INTO
		Produces(PersonID, MovieID)
	VALUES
		(@personID, @movieID)