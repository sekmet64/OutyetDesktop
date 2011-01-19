CREATE TABLE [dbo].[Users] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [Username]  VARCHAR (50) NOT NULL,
    [FirstName] VARCHAR (50) NULL,
    [LastName]  VARCHAR (50) NULL,
    [Password]  BINARY (20)  NOT NULL,
    [Rank]      INT          NOT NULL
);



