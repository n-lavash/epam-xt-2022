-- ���������� ������ ��� ����������� ���������� ������ � Role
CREATE UNIQUE INDEX Role_Index
ON Role(Name_Role)

-- ���������� ������� ��� ����������� ���������� ����� � id
CREATE UNIQUE INDEX UserEmail_Index
ON Users(Email)

CREATE UNIQUE INDEX UserID_Index
ON Users(ID_Account)

-- ���������� ������� ��� ����������� ���������� ������ � id
CREATE UNIQUE INDEX AcDetID_Index
ON AccountDetails(ID_User)

CREATE UNIQUE INDEX AcDetLogin_Index
ON AccountDetails(Login_User)

-- ���������� ������ ��� ����������� ���������� id
CREATE UNIQUE INDEX AcRol_Index
ON Account_Role(ID_Account)