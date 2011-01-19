CREATE PROCEDURE [dbo].[GetProducersForMovie]
	@movieID INT 
AS
	SELECT P.Name
	FROM
		Produces PR JOIN
		Persons P ON P.ID = PR.PersonID
	WHERE
		PR.MovieID = @movieID
RETURN 0