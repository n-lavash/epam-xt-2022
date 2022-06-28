SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Auction_GetLots]
	@parametr SQL_VARIANT
as
BEGIN
	SET	NOCOUNT ON;
	SELECT
		ID_Lot, Name_Lot, Date_added, Price, Decription
	FROM Lot
	WHERE Name_Lot LIKE cast(@parametr as nvarchar(255)) + '%'
	OR Date_added = cast(@parametr as datetime)
	OR Price = @parametr
END