USE [FlightManagerDB];
GO

IF OBJECT_ID('dbo.Reservation', 'U') IS NOT NULL
DROP TABLE dbo.Reservation;
GO

CREATE TABLE dbo.Reservation (
    ReservationID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    EGN CHAR(10) NOT NULL UNIQUE,
	Email VARCHAR(50),
    PhoneNumber VARCHAR(20) NOT NULL UNIQUE,
    Nationality VARCHAR(50) NOT NULL,
    TicketType VARCHAR(20) NOT NULL,
    FlightID INT NOT NULL,
    FOREIGN KEY (FlightID) REFERENCES Flight(FlightID), 
);
GO


