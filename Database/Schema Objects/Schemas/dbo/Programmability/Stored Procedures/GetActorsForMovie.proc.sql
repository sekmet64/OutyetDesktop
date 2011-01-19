CREATE PROCEDURE [dbo].[GetActorsForMovie]
	@movieID INT 
AS
	SELECT P.Name
	FROM
		Acts A JOIN
		Persons P ON P.ID = A.PersonID
	WHERE
		A.MovieID = @movieID
RETURN 0