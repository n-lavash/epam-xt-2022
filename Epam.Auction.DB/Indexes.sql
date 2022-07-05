CREATE UNIQUE INDEX RolesName_Index
ON Roles(Name)

CREATE UNIQUE INDEX UsersEmail_Index
ON Users(Email)

CREATE UNIQUE INDEX AcDetLogin_Index
ON AccountDetails(Login)

CREATE UNIQUE INDEX AcRol_Index
ON AccountsToRole(AccountID)

CREATE UNIQUE INDEX UsToLot_Index
ON UsersToLots(UserID, LotID)