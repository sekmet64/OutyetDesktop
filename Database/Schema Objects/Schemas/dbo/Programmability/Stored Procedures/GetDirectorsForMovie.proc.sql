CREATE PROCEDURE [dbo].[GetDirectorsForMovie]
	@movieID INT 
AS
	SELECT P.Name
	FROM
		Directs D JOIN
		Persons P ON P.ID = D.PersonID
	WHERE
		D.MovieID = @movieID
RETURN 0