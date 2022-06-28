SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_EditLot
	@ID int,
	@Name_Lot nvarchar(255),
	@Date_added datetime,
	@Price float,
	@Decription nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Lot
	SET Name_Lot = @Name_Lot, Date_added = @Date_added, Price = @Price, Decription = @Decription
	WHERE ID_Lot = @ID
END
GO
