SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_EditLot
	@ID int,
	@Name nvarchar(255),
	@Date_added datetime,
	@Price decimal(19,4),
	@Description nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Lots
	SET Name = @Name, Date_added = @Date_added, Price = @Price, Description = @Description
	WHERE ID = @ID
END
GO
