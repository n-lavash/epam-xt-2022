SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetLotsByPrice
	@numberFrom decimal(19,4),
	@numberTo decimal(19,4)
as
BEGIN
	SET	NOCOUNT ON;
	IF (@numberTo = -1)
		BEGIN
		SELECT ID, Name, Date_added, Price, Description
		FROM Lots
		WHERE Price >= @numberFrom
		END
	ELSE
		BEGIN
		SELECT ID, Name, Date_added, Price, Description
		FROM Lots
		WHERE Price BETWEEN @numberFrom AND @numberTo
		END
END
GO