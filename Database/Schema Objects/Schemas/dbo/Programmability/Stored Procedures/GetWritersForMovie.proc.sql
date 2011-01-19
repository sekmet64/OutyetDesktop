CREATE PROCEDURE [dbo].[GetWritersForMovie]
	@movieID INT 
AS
	SELECT P.Name
	FROM
		Writes W JOIN
		Persons P ON P.ID = W.PersonID
	WHERE
		W.MovieID = @movieID
RETURN 0