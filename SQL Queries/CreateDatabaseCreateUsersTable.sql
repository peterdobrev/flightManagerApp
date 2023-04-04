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
DROP TABLE dbo.Users;
GO

CREATE TABLE dbo.[User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    EGN NVARCHAR(10) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
GO
