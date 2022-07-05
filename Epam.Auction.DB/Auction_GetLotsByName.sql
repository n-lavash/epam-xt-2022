SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetLotsByName
	@line nvarchar(255)
as
BEGIN
	SET	NOCOUNT ON;
	SELECT
		ID, Name, Date_added, Price, Description
	FROM Lots
	WHERE Name LIKE @line + '%'
END
