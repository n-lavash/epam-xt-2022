SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_EditUser
	@ID int,
	@Birthdate datetime,
	@Name nvarchar(255),
	@Registration_date datetime,
	@Email nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users
	SET Birthdate = @Birthdate, Name = @Name, Registration_date = @Registration_date, Email = @Email
	WHERE ID = @ID
END
GO
