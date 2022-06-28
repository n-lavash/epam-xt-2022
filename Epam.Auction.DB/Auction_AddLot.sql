SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Auction_AddLot
	@Name_Lot nvarchar(255),
	@Date_added datetime,
	@Price float,
	@Description nvarchar(max)
as
BEGIN
	SET	NOCOUNT OFF;
	INSERT INTO dbo.Lot(Name_Lot, Date_added, Price, Decription)
	VALUES(@Name_Lot, @Date_added, @Price, @Description)
END
