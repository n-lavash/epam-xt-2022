CREATE TRIGGER Roles_Insert
ON Roles
INSTEAD OF INSERT AS
BEGIN
DECLARE @Role NVARCHAR(16) = (SELECT Name FROM INSERTED)
DECLARE @Last_ID int = (SELECT MAX(ID) FROM Roles)
IF (@Last_ID < 2 OR @Last_ID IS NULL)
	INSERT INTO Roles VALUES(@Role)
ELSE
	BEGIN
	ROLLBACK TRANSACTION
	RAISERROR ('Exceeded the number of possible fields', 16, 10)
	END
END