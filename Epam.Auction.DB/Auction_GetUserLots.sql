SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetUserLots
	@ID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Lots.ID, Lots.Name, Date_added, Price, Description
	FROM Lots
	INNER JOIN UsersToLots ON (LotID = Lots.ID)
	INNER JOIN Users ON (UserID = Users.ID)
	WHERE Users.ID = @ID
END
GO
