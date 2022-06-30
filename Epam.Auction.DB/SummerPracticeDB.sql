drop DATABASE Auction
go

CREATE DATABASE Auction

USE Auction

-- только 2 поля
create table Role (
ID_Role int IDENTITY(1,1) CONSTRAINT PK_Role PRIMARY KEY NOT NULL,
Name_Role nvarchar(25) NOT NULL)

create table Users (
ID_User int IDENTITY(1,1) CONSTRAINT PK_Users PRIMARY KEY NOT NULL,
ID_Account int  NOT NULL,
Birthdate datetime NOT NULL,
Name_User nvarchar(255) NOT NULL,
Registration_date datetime NOT NULL,
Email nvarchar(255) NOT NULL)

create table Lot (
ID_Lot int IDENTITY(1,1) CONSTRAINT PK_Lot PRIMARY KEY NOT NULL,
Name_Lot nvarchar(255) NOT NULL,
Date_added datetime NOT NULL,
Price float NOT NULL,
Decription nvarchar(400))

create table User_Lot (
ID_User int FOREIGN KEY REFERENCES Users(ID_User) NOT NULL,
ID_Lot int FOREIGN KEY REFERENCES Lot(ID_Lot) NOT NULL)

create table AccountDetails (
ID_Account int IDENTITY(1,1) CONSTRAINT PK_AccountDetails PRIMARY KEY NOT NULL,
ID_User int FOREIGN KEY REFERENCES Users(ID_User) NOT NULL,
Login_User nvarchar(255) NOT NULL,
Password_User nvarchar(255) NOT NULL)

create table Account_Role (
ID_Role int FOREIGN KEY REFERENCES Role(ID_Role) NOT NULL,
ID_Account int FOREIGN KEY REFERENCES AccountDetails(ID_Account) NOT NULL)