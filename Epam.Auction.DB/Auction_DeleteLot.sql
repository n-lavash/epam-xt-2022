SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Auction_DeleteLot
	@ID_Lot int
as
BEGIN
	SET	NOCOUNT OFF;
	DELETE FROM Lot WHERE ID_Lot = @ID_Lot
END
