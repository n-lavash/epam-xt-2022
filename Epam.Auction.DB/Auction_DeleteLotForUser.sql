SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_DeleteLotForUser
	@LotID int,
	@UserID int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM UsersToLots WHERE @LotID = LotID AND @UserID = UserID
END
GO
