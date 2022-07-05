SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetAccountById
	@ID int
as
BEGIN
	SET	NOCOUNT ON;
	SELECT TOP 1
		AccountDetails.ID, Login, Password,
		Roles.Name FROM AccountDetails
	INNER JOIN AccountsToRole ON (AccountsToRole.AccountId = AccountDetails.ID)
	INNER JOIN Roles ON (Roles.ID = AccountDetails.ID)
	WHERE AccountDetails.ID = @ID
END
