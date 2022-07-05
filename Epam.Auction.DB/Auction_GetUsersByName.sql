SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetUsersByName
	@line nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ID, Name, Birthdate, Email, Registration_date FROM Users
	WHERE Name LIKE @line + '%'
END
GO
