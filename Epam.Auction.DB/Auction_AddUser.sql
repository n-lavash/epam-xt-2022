SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_AddUser
	@Birthdate datetime,
	@Name nvarchar(255),
	@Registration_date datetime,
	@Email nvarchar(255),
	@Login nvarchar(255),
	@Password nvarchar(255)	
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @UserID int = (SELECT MAX(ID) FROM Users)
	SET @UserID = @UserID + 1
	DECLARE @RoleID int = (SELECT ID FROM Roles WHERE Roles.Name = 'user')
	INSERT INTO Users VALUES(@Birthdate, @Name, @Registration_date, @Email)
	INSERT INTO AccountDetails VALUES(@Login, HASHBYTES('SHA2_512',@Password))
	INSERT INTO AccountsToRole VALUES(@RoleID, @UserID)
END
GO
