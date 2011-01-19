CREATE PROCEDURE [dbo].[GetListID]
	@userID int,
	@list varchar(50),
	@listID int OUT
AS
	SELECT
		@listID = L.ID
	FROM
		Lists L
	WHERE
		L.[Owner] = @userID and
		L.Name = @list
RETURN 0