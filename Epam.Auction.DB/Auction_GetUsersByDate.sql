SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetUsersByDate
	@dateFrom datetime,
	@dateTo datetime
AS
BEGIN
	SET	NOCOUNT ON;
	IF (@dateTo = '1900')
		BEGIN
		SELECT ID, Name, Birthdate, Email, Registration_date FROM Users
		WHERE Birthdate >= @dateFrom
		END
	ELSE IF (@dateFrom = '1900')
		BEGIN
		SELECT ID, Name, Birthdate, Email, Registration_date FROM Users
		WHERE Birthdate <= @dateTo
		END
	ELSE
		BEGIN
		SELECT ID, Name, Birthdate, Email, Registration_date FROM Users
		WHERE Birthdate BETWEEN @dateFrom AND @dateTo
		END
END
GO
