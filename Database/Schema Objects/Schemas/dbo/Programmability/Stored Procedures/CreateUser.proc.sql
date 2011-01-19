CREATE PROCEDURE [dbo].[CreateUser]
	@username VARCHAR(50),
	@firstName VARCHAR(50),
	@lastName VARCHAR(50),
	@password VARCHAR(50)
AS
	INSERT
	INTO
		Users (Username, FirstName, LastName, [Password], [Rank])
	VALUES(@username, @firstName, @lastName, HASHBYTES('SHA1', @password), 100)

RETURN 0