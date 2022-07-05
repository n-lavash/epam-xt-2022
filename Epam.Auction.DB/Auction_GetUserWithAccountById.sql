SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_GetUserWithAccountById
	@ID int
as
BEGIN
	SET	NOCOUNT ON;
	SELECT 
	Users.ID, Roles.Name, Birthdate,
	Users.Name, Email, Login, 
	Password, Registration_date,
	Lots.Name as Lot
	FROM Users 
	INNER JOIN AccountsToRole ON (AccountsToRole.AccountID = Users.ID)
	INNER JOIN Roles ON (AccountsToRole.RoleID = Roles.ID)
	INNER JOIN AccountDetails ON (AccountDetails.ID = Users.ID)
	INNER JOIN UsersToLots ON (UserID = Users.ID)
	INNER JOIN Lots ON (Lots.ID = UsersToLots.LotID)
	WHERE Users.ID = @ID
END
