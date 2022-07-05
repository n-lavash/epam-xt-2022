SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Auction_CheckAccount
	@Password nvarchar(64),
	@Login nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT(Login) FROM AccountDetails WHERE Login = @Login AND Password = HASHBYTES('SHA2_512', @Password)
END
GO
