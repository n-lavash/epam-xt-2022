SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetLotsByDate
	@dateFrom datetime,
	@dateTo datetime
AS
BEGIN
	SET	NOCOUNT ON;
	IF (@dateTo = '1900')
		BEGIN
		SELECT ID, Name, Date_added, Price, Description
		FROM Lots
		WHERE Date_added >= @dateFrom
		END
	ELSE IF (@dateFrom = '1900')
		BEGIN
		SELECT ID, Name, Date_added, Price, Description
		FROM Lots
		WHERE Date_added <= @dateTo
		END
	ELSE
		BEGIN
		SELECT ID, Name, Date_added, Price, Description
		FROM Lots
		WHERE Date_added BETWEEN @dateFrom AND @dateTo
		END
END
GO
