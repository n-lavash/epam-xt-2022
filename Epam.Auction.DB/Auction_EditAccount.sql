SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_EditAccount
	@ID int,
	@Login nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	UPDATE AccountDetails
	SET Login = @Login, Password = HASHBYTES('SHA2_512', @Password)
	WHERE ID = @ID
END
GO
