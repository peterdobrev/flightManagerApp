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

INSERT INTO dbo.Flight (DepartureLocation, ArrivalLocation, DepartureDateTime, ArrivalDateTime, PlaneType, PlaneNumber, PilotName, PassengerCapacity, BusinessClassCapacity)
VALUES 
('New York', 'Los Angeles', '2023-05-06 08:00:00', '2023-05-06 12:00:00', 'Boeing 737', 'BA345', 'John Smith', 150, 20),
('Los Angeles', 'Chicago', '2023-05-07 10:00:00', '2023-05-07 14:00:00', 'Airbus A320', 'AA678', 'Sarah Johnson', 200, 30),
('Chicago', 'Houston', '2023-05-08 12:00:00', '2023-05-08 16:00:00', 'Boeing 777', 'UA901', 'David Lee', 250, 40),
('Houston', 'Miami', '2023-05-09 14:00:00', '2023-05-09 18:00:00', 'Boeing 737', 'DL123', 'Jessica Chen', 180, 25),
('Miami', 'New York', '2023-05-10 16:00:00', '2023-05-10 20:00:00', 'Airbus A320', 'UA234', 'Kevin Brown', 220, 35);
GO
