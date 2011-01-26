CREATE TRIGGER [AddListTrigger]
ON Lists
INSTEAD OF INSERT
AS 
BEGIN
	DECLARE @list VARCHAR(50);

	SELECT
		@list = Name
	FROM
		inserted

	IF @list = '- followed artists -'
		ROLLBACK TRAN
END
