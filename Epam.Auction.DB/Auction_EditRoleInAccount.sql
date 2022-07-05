SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_EditRoleInAccount
	@ID int,
	@Name nvarchar(25)
AS
BEGIN
	DECLARE @ID_Role int
	IF @Name = 'user' SET @ID_Role = (SELECT ID FROM Roles WHERE Name = @Name)
	ELSE SET @ID_Role = (SELECT ID FROM Roles WHERE Name = @Name)
	UPDATE AccountsToRole
	SET RoleID = @ID_Role
	WHERE AccountID = @ID
END
GO
