USE [FlightManagerDB];
GO

IF OBJECT_ID('dbo.Flight', 'U') IS NOT NULL
DROP TABLE dbo.Flight;
GO

CREATE TABLE dbo.Flight (
    FlightID INT IDENTITY(1,1) PRIMARY KEY,
    DepartureLocation NVARCHAR(100) NOT NULL,
    ArrivalLocation NVARCHAR(100) NOT NULL,
    DepartureDateTime DATETIME NOT NULL,
    ArrivalDateTime DATETIME NOT NULL,
    PlaneType NVARCHAR(100) NOT NULL,
    PlaneNumber NVARCHAR(100) NOT NULL,
    PilotName NVARCHAR(100) NOT NULL,
    PassengerCapacity INT NOT NULL,
    BusinessClassCapacity INT NOT NULL
);
GO
