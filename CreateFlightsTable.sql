USE [FlightManagerDB];
GO

IF OBJECT_ID('dbo.Flight', 'U') IS NOT NULL
DROP TABLE dbo.Flight;
GO

CREATE TABLE Flights (
    FlightID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    LocationFrom VARCHAR(50) NOT NULL,
    LocationTo VARCHAR(50) NOT NULL,
    DepartureDateTime DATETIME NOT NULL,
    ArrivalDateTime DATETIME NOT NULL,
    PlaneType VARCHAR(50) NOT NULL,
    PlaneRegistrationNumber VARCHAR(20) NOT NULL UNIQUE,
    PilotName VARCHAR(50) NOT NULL,
    CapacityPassengers INT NOT NULL,
    CapacityBusinessClass INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO
