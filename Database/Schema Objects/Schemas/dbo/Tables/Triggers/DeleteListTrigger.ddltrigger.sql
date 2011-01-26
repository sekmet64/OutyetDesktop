CREATE TRIGGER [DeleteListTrigger]
ON Lists
INSTEAD OF DELETE
AS 
BEGIN

	DECLARE @list VARCHAR(50);

	SELECT
		@list = Name
	FROM
		deleted

	IF @list = '- followed artists -'
		ROLLBACK TRAN
END
