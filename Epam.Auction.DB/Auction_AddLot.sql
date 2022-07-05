SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_AddLot
	@Name nvarchar(255),
	@Date_added datetime,
	@Price decimal(19,4),
	@Description nvarchar(max)
as
BEGIN
	SET	NOCOUNT ON;
	INSERT INTO Lots(Name, Date_added, Price, Description)
	VALUES(@Name, @Date_added, @Price, @Description)
END