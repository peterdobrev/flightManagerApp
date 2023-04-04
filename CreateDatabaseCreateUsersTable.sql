USE [master];
GO

IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'FlightManagerDB')
BEGIN
    PRINT 'FlightManagerDB database already exists.'
END
ELSE
BEGIN
    CREATE DATABASE [FlightManagerDB];
    PRINT 'FlightManagerDB database created.'
END
GO

USE [FlightManagerDB];
GO

IF OBJECT_ID('dbo.User', 'U') IS NOT NULL
DROP TABLE dbo.[User];
GO

CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    EGN CHAR(10) NOT NULL UNIQUE,
    Address VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL UNIQUE,
    Role VARCHAR(20) NOT NULL
);
GO

TRUNCATE TABLE [USER];

INSERT INTO [User] (Username, Password, Email, FirstName, LastName, EGN, Address, PhoneNumber, Role)
VALUES ('admin', 'admin', 'admin@admin.com', 'Admin', 'Admin', '0000000000', 'Admin', '0000000000', 'admin');
