CREATE PROCEDURE [dbo].[GetListEntries]
	@username VARCHAR(50), 
	@list VARCHAR(50)
AS
	DECLARE @userID INT;
	EXEC GetUserID @username, @userID OUT;

	IF @list <> '- followed artists -'
	BEGIN
		

		DECLARE @listID INT;
		EXEC GetListID @userID, @list, @listID OUT

		SELECT 
			M.ID, M.ReleaseDate, M.Title
		FROM
			ListEntries LE JOIN Movies M ON LE.Movie = M.ID
		WHERE
			LE.List = @listID
	END
	ELSE
	BEGIN
		SELECT
			M.ID, M.ReleaseDate, M.Title
		FROM
			Movies M JOIN
			Acts A ON M.ID = A.MovieID JOIN
			Directs D ON M.ID = D.MovieID JOIN
			Produces PR ON M.ID = PR.MovieID JOIN
			Writes W ON M.ID = W.MovieID JOIN
			Follows F ON A.PersonID = F.PersonID OR D.PersonID = F.PersonID OR PR.PersonID = F.PersonID OR W.PersonID = F.PersonID JOIN
			Persons P ON F.PersonID = P.ID
		WHERE
			F.UserID = @userID
	END

RETURN 0