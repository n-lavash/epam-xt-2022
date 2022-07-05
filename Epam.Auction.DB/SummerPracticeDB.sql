drop DATABASE Auction
go

CREATE DATABASE Auction

USE Auction

create table Roles (
ID int IDENTITY(1,1) CONSTRAINT PK_Roles PRIMARY KEY NOT NULL,
Name nvarchar(25) NOT NULL)

create table Users (
ID int IDENTITY(1,1) CONSTRAINT PK_Users PRIMARY KEY NOT NULL,
Birthdate datetime NOT NULL,
Name nvarchar(255) NOT NULL,
Registration_date datetime NOT NULL,
Email nvarchar(255) NOT NULL)

create table Lots (
ID int IDENTITY(1,1) CONSTRAINT PK_Lots PRIMARY KEY NOT NULL,
Name nvarchar(255) NOT NULL,
Date_added datetime NOT NULL,
Price decimal(19,4) NOT NULL,
Description nvarchar(max))

create table UsersToLots (
UserID int FOREIGN KEY REFERENCES Users(ID) NOT NULL,
LotID int FOREIGN KEY REFERENCES Lots(ID) NOT NULL)

create table AccountDetails (
ID int IDENTITY(1,1) CONSTRAINT PK_AccountDetails PRIMARY KEY FOREIGN KEY REFERENCES Users(ID) NOT NULL,
Login nvarchar(255) NOT NULL,
Password binary(64) NOT NULL)

create table AccountsToRole (
RoleID int FOREIGN KEY REFERENCES Roles(ID) NOT NULL,
AccountID int FOREIGN KEY REFERENCES AccountDetails(ID) NOT NULL)