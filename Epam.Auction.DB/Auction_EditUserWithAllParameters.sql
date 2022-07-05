SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_EditUserWithAllParameters
	@ID int,
	@Birthdate datetime,
	@Name nvarchar(255),
	@Registration_date datetime,
	@Email nvarchar(255),
	@Login nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	EXEC Auction_EditUser @ID, @Birthdate, @Name, @Registration_date, @Email
	EXEC Auction_EditAccount @ID, @Login, @Password
END
GO
