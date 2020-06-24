-------1
CREATE TABLE Planes (
   Id INT PRIMARY KEY IDENTITY
   ,[Name] VARCHAR(30) NOT NULL
   ,Seats INT NOT NULL
   ,[Range] INT NOT NULL
);

CREATE TABLE Flights (
   Id INT PRIMARY KEY IDENTITY
   ,DepartureTime DATETIME
   ,ArrivalTime DATETIME
   ,Origin VARCHAR(50) NOT NULL
   ,Destination VARCHAR(50) NOT NULL
   ,PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
);

CREATE TABLE Passengers (
   Id INT PRIMARY KEY IDENTITY
   ,FirstName VARCHAR(30) NOT NULL
   ,LastName VARCHAR(30) NOT NULL
   ,Age INT NOT NULL 
   ,[Address] VARCHAR(30) NOT NULL
   ,PassportId CHAR(11) NOT NULL 
);

CREATE TABLE LuggageTypes (
   Id INT PRIMARY KEY IDENTITY
   ,[Type] VARCHAR(30) NOT NULL
);

CREATE TABLE Luggages (
   Id INT PRIMARY KEY IDENTITY
   ,LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id)
   ,PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
);

CREATE TABLE Tickets (
   Id INT PRIMARY KEY IDENTITY
   ,PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
   ,FlightId  INT NOT NULL FOREIGN KEY REFERENCES Flights(Id)
   ,LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id)
   ,Price DECIMAL (18,2) NOT NULL
);

------2
INSERT INTO PLANES([Name],Seats,[Range])
VALUES('Airbus 336',112,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)


INSERT INTO LuggageTypes(Type)
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

------3
UPDATE Tickets
SET Price *= 1.13 
WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Carlsbad');

----4
DELETE FROM Tickets WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim');
DELETE FROM Flights WHERE Destination = 'Ayn Halagim';

----5
--Select all of the planes, which name contains "tr". Order them by id (ascending), name (ascending), seats (ascending) and range (ascending).

SELECT 
	*
FROM 
	Planes 
WHERE
	[Name] LIKE '%tr%'
ORDER BY
	Id,Name,Seats,Range

-----6
---Select the total profit for each flight from database. Order them by total price (descending), flight id (ascending).
SELECT 
	FlightId,SUM(Price) AS 'Price'
FROM 
	Tickets
GROUP BY
	FlightId
ORDER BY
	Price DESC,FlightId

-----7
--Select the full name of the passengers with their trips (origin - destination). 
--Order them by full name (ascending), origin (ascending) and destination (ascending).

SELECT 
	p.FirstName +' '+ p.LastName AS 'Full Name',f.Origin,f.Destination
FROM
	Passengers AS p JOIN Tickets AS t ON p.Id = t.PassengerId
	JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY
	[Full Name],Origin,Destination

-----8
SELECT 
	p.FirstName,p.LastName,p.Age
FROM
	Passengers AS p
WHERE
	p.Id NOT IN(SELECT PassengerId FROM Tickets)
ORDER BY
	Age DESC,FirstName,LastName

-----9
SELECT 
	*
FROM
	Passengers AS p JOIN Tickets AS t ON p.Id = t.PassengerId
	JOIN Flights AS f ON f.Id = t.FlightId
	JOIN Planes AS pl ON pl.Id = f.PlaneId
	JOIN Luggages AS l ON l.Id = t.LuggageId 
	JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY 
	[Full Name],pl.Name,F.Origin,F.Destination,[Luggage Type]

----10
SELECT 
	mt.Name,mt.Seats,SUM(mt.PassengerOn) AS 'Passengers Count'
FROM
	(SELECT 
		p.Name , p.Seats,
		CASE
		WHEN t.Id IS NULL THEN 0
		ELSE 1
	END AS PassengerOn
	FROM
		Planes AS p LEFT JOIN Flights AS f ON p.Id = f.PlaneId
		LEFT JOIN Tickets AS t ON t.FlightId = f.Id) AS mt
GROUP BY
	mt.Name,mt.Seats
ORDER BY
	[Passengers Count] DESC,mt.Name,mt.Seats

----11

ALTER FUNCTION udf_CalculateTickets(@origin VARCHAR(MAX), @destination VARCHAR(MAX), @peopleCount INT) 
RETURNS VARCHAR(MAX)   
AS   
BEGIN 

DECLARE @invalidPeople VARCHAR(MAX) =  'Invalid people count!'
DECLARE @invalidFlight VARCHAR(MAX) =  'Invalid flight!'

IF(@peopleCount <= 0)
	BEGIN
	RETURN @invalidPeople
	END

IF(@origin NOT IN (SELECT Origin FROM Flights) OR @destination NOT IN (SELECT Destination FROM Flights))
	BEGIN
	RETURN @invalidFlight
	END

DECLARE @totalPrice DECIMAL(18,2) =  (SELECT TOP(1) t.Price FROM Flights AS f JOIN Tickets AS t ON t.FlightId= f.Id WHERE f.Destination = @destination AND f.Origin = @Origin ) * @peopleCount
RETURN 'Total price '+ CAST ( @totalPrice AS VARCHAR(MAX)) 
END

-----12

CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime
END

