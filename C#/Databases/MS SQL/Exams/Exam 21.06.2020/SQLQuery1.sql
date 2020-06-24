------1
CREATE TABLE Cities (
   Id INT PRIMARY KEY IDENTITY
   ,[Name] NVARCHAR(20) NOT NULL
   ,CountryCode CHAR(2) NOT NULL
);

CREATE TABLE Hotels (
   Id INT PRIMARY KEY IDENTITY
   ,[Name] NVARCHAR(30) NOT NULL 
   ,CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id)
   ,EmployeeCount INT NOT NULL
   ,BaseRate DECIMAL(18,2)
);

CREATE TABLE Rooms (
   Id INT PRIMARY KEY IDENTITY
   ,Price DECIMAL(18,2) NOT NULL
   ,[Type] NVARCHAR(20) NOT NULL 
   ,Beds INT NOT NULL
   ,HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
);

CREATE TABLE Trips (
   Id INT PRIMARY KEY IDENTITY
   ,RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
   ,BookDate DATE NOT NULL 
   ,ArrivalDate DATE NOT NULL 
   ,ReturnDate DATE NOT NULL 
   ,CancelDate DATE
   ,CONSTRAINT CHK_BookDate CHECK (BookDate < ArrivalDate)
   ,CONSTRAINT CHK_ArrivalDate CHECK (ArrivalDate < ReturnDate)
);

CREATE TABLE Accounts (
   Id INT PRIMARY KEY IDENTITY
   ,FirstName NVARCHAR(50) NOT NULL 
   ,MiddleName NVARCHAR(20)
   ,LastName NVARCHAR(50) NOT NULL 
   ,CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id)
   ,BirthDate DATE NOT NULL 
   ,Email VARCHAR(100) UNIQUE NOT NULL 
);

CREATE TABLE AccountsTrips (
   AccountId  INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id)
   ,TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id)
   ,Luggage INT NOT NULL
   ,CONSTRAINT CHK_Luggage CHECK (Luggage>=0)
   ,PRIMARY KEY (AccountId, TripId)
);

------2
INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email)
VALUES('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL	,'Petrov',	11	,'1978-05-16',	'g_petrov@gmail.com'),
('Ivan'	,'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId,BookDate,ArrivalDate,ReturnDate,CancelDate)
VALUES(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

------3 Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.

UPDATE ROOMS
SET Price *= 1.14
WHERE HotelId IN (5,7,9) 

------4
--Delete all of Account ID 47’s account’s trips from the mapping table.
DELETE FROM AccountsTrips WHERE AccountId = 47

------5
SELECT 
	a.FirstName,a.LastName,FORMAT (a.BirthDate, 'MM-dd-yyyy') AS BirthDate,c.Name AS 'Hometown',A.Email
FROM
	Accounts AS a JOIN Cities AS c ON a.CityId = c.Id
WHERE
	a.Email LIKE 'e%'
ORDER BY 
	c.Name

------6
SELECT
	c.Name , COUNT(c.Name) AS Hotels
FROM
	Hotels AS h JOIN Cities AS c ON h.CityId = c.Id
GROUP BY
	c.Name
ORDER BY
	Hotels DESC,c.Name

------7
SELECT
	a.Id AS 'AccountId'
	,a.FirstName + ' ' + a.LastName AS 'FullName'
	,MAX(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS LongestTrip
	,MIN(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS ShortestTrip
FROM
	Accounts AS a JOIN AccountsTrips AS att ON a.Id = att.AccountId
	JOIN Trips AS t ON t.Id = att.TripId
WHERE
	a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY
	a.Id,a.FirstName,a.LastName
ORDER BY	
	LongestTrip DESC ,ShortestTrip

------8
SELECT TOP 10
	c.Id,c.Name AS City,c.CountryCode AS Country,COUNT(c.Id) AS Accounts
FROM
	Accounts AS a JOIN Cities AS c ON a.CityId = c.Id
GROUP BY
	c.Id,c.Name,c.CountryCode
ORDER BY
	Accounts DESC

------9
SELECT
	a.Id,a.Email,c.Name AS 'City',COUNT(a.Id) AS Trips
FROM
	Accounts AS a JOIN Cities AS c ON a.CityId = c.Id
	JOIN AccountsTrips AS att ON a.Id = att.AccountId
	JOIN Trips AS t ON t.Id = att.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
WHERE 
	h.CityId = a.CityId
GROUP BY
	a.Id,a.Email,c.Name
ORDER BY
	Trips DESC,a.Id

------10
SELECT
	t.Id,
	a.FirstName + ISNULL (' '+ a.MiddleName+' ',' ') + a.LastName AS 'Full Name',
	c.Name AS 'From',
	cc.Name AS 'To' ,
	CASE
    WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
    ELSE CONVERT(varchar(10), DATEDIFF(DAY,ArrivalDate,ReturnDate)) + ' days'
END AS Duration
FROM
	Accounts AS a JOIN Cities AS c ON a.CityId = c.Id
	JOIN AccountsTrips AS att ON a.Id = att.AccountId
	JOIN Trips AS t ON t.Id = att.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS cc ON cc.Id = h.CityId
ORDER BY
	[Full Name],TripId


----12
go
CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
BEGIN TRANSACTION
DECLARE @hotelID INT = (SELECT r.HotelId FROM Trips AS t JOIN Rooms AS r ON t.RoomId = r.Id WHERE t.Id = @TripId)
DECLARE @roomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)

IF(@hotelID != @roomHotelId)
	BEGIN
		ROLLBACK
		RAISERROR('Target room is in another hotel!',16,1)
		RETURN
	END

DECLARE @peopleCount INT = (SELECT COUNT(TripId) FROM AccountsTrips WHERE TripId = @TripId)
DECLARE @roomBeds INT = (SELECT Beds FROM Rooms WHERE Id=@TargetRoomId)

IF(@peopleCount>@roomBeds)
	BEGIN
			ROLLBACK
			RAISERROR('Not enough beds in target room!',16,2)
			RETURN
	END

UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId
COMMIT
END

------11
GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS   
BEGIN 
DECLARE @returnError VARCHAR(MAX) = 'No rooms available'
DECLARE @MyTable TABLE 
(
   Price DECIMAL(18,2),
   RoomId INT,
   RoomType NVARCHAR(20),
   Beds INT
)
INSERT INTO @MyTable 
SELECT TOP 1 
	(h.BaseRate + r.Price) * @People AS Total , r.Id , r.Type , r.Beds
FROM
	Trips AS t JOIN Rooms AS r ON t.RoomId = r.Id JOIN Hotels AS h ON h.Id = r.HotelId
WHERE
	r.Id NOT IN ((SELECT r.Id
					FROM 
						Trips AS t JOIN Rooms AS r ON t.RoomId = r.Id 
					WHERE 
						(@Date BETWEEN ArrivalDate AND ReturnDate) AND 
						CancelDate IS NULL)) 
						AND r.HotelId = @HotelId
						AND r.Beds >= @People
ORDER BY
	Total DESC

DECLARE @Price DECIMAL(18,2) = (SELECT Price FROM @MyTable)
DECLARE @RoomId INT = (SELECT RoomId FROM @MyTable)
DECLARE @Type NVARCHAR(20) = (SELECT RoomType FROM @MyTable)
DECLARE @Beds INT = (SELECT Beds FROM @MyTable)

DECLARE @returnPrice VARCHAR(MAX) = 'Room '+ CONVERT(varchar(10), @RoomId)+ ': ' + @Type + ' ('+CONVERT(varchar(10), @Beds)+' beds) - $'+CONVERT(varchar(10), @Price)

IF (@Price IS NULL)
	BEGIN
	RETURN @returnError
	END
 
RETURN @returnPrice
END


	
