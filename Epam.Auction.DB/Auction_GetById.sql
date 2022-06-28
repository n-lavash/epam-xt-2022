SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE PROCEDURE dbo.Auction_GetById
	@id int
as
BEGIN
	SET	NOCOUNT ON;
	SELECT TOP 1
		ID_Lot, Name_Lot, Date_added, Price, Decription
	FROM Lot
	WHERE ID_Lot = @id
END