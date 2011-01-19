CREATE TRIGGER [CreateFollowedList]
ON Users
AFTER INSERT 
AS 
BEGIN
	--SET NOCOUNT ON

	INSERT INTO
		Lists (Name, [Owner])
	VALUES
		('- followed artists -', (SELECT ID FROM inserted))
END
