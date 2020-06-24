CREATE DATABASE Minions
------Problem 7.	Create Table People
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height FLOAT(2),
Weight FLOAT(2),
Gender CHAR NOT NULL ,
Birthdate DATE NOT NULL,
Biography NTEXT
)

ALTER TABLE People ADD CONSTRAINT CHK_T_Picture__2MB CHECK (DATALENGTH(Picture) <= 2097152);

ALTER TABLE People ADD CONSTRAINT CHK_T_Gender__MorF 
    CHECK (Gender IN ('m', 'f') );

SET IDENTITY_INSERT People OFF

INSERT INTO People(Id,[Name],Picture,Height,Weight,Gender,Birthdate,Biography)
VALUES(1,'Ivan',NULL,1.83,72.45,'m','12-08-1987','No biography'),
      (2,'Stavri',NULL,1.45,45.00,'m','11-12-2003','Still Nothing'),
	  (3,'Kolio',NULL,2.00,65.1,'m','03-08-1898','Empty String'),
	  (4,'Temenujka',NULL,1.63,32.33,'f','05-03-1989','No biography'),
	  (5,'Petka',NULL,1.23,150.66,'f','03-05-2001','No biography')

---------------------------Problem 8.	Create Table Users

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(26) NOT NULL,
ProfilePicture  VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

ALTER TABLE Users ADD CONSTRAINT CHK_ProfilePicture__900KB CHECK (DATALENGTH(ProfilePicture) <= 900000);
SET IDENTITY_INSERT Users ON

INSERT INTO Users(Id,Username,Password,ProfilePicture,LastLoginTime,IsDeleted)
VALUES(1,'Ivan_vt','123qwe',NULL,'12-08-1987 03:44:40',1),
      (2,'Stavri_bg','123asd',NULL,'03-05-2001 12:46:44',0),
	  (3,'Kolio_hgb','123rew',NULL,'03-08-1898 02:13:42',1),
	  (4,'Temenujka_89','423cz',NULL,'05-03-1989 01:54:30',0),
	  (5,'Petka_345','54234',NULL,DEFAULT,1)

------Problem 9.	Change Primary Key
ALTER TABLE Users 
DROP CONSTRAINT [PK__Users__3214EC07408DE993]

ALTER TABLE Users 
ADD CONSTRAINT PK__Users PRIMARY KEY(Id,Username)

------Problem 10.	Add Check Constraint

ALTER TABLE Users 
ADD CONSTRAINT PK__Password CHECK(DATALENGTH(Password) > 4)

-----Problem 11.	Set Default Value of a Field

ALTER TABLE Users ADD CONSTRAINT LastLoginTime_CurrentTime DEFAULT GETDATE() FOR LastLoginTime

------- Problem 12.	Set Unique Field

ALTER TABLE Users 
DROP CONSTRAINT [PK__Users__3214EC078171CC0A]

ALTER TABLE Users 
ADD CONSTRAINT PK__Users PRIMARY KEY(Id)

ALTER TABLE Users 
ADD CONSTRAINT PK__Username CHECK(DATALENGTH(Username) > 2)

------ Problem 13.	Movies Database

CREATE DATABASE Movies

CREATE TABLE Directors (
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NTEXT,
)

SET IDENTITY_INSERT Directors ON
INSERT INTO Directors(Id,DirectorName,Notes)
VALUES(1,'Ivan','123qwe'),
      (2,'Stavri','123asd'),
	  (3,'Kolio','123rew'),
	  (4,'Temenujka','423cz'),
	  (5,'Petka',NULL)
SET IDENTITY_INSERT Directors OFF

CREATE TABLE Genres (
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR NOT NULL,
Notes NTEXT,
)

SET IDENTITY_INSERT Genres ON
INSERT INTO Genres(Id,GenreName,Notes)
VALUES(1,'m','aaa'),
      (2,'m','bbb'),
	  (3,'m','ccc'),
	  (4,'f','ddd'),
	  (5,'f','eee')
SET IDENTITY_INSERT Genres OFF

CREATE TABLE Categories (
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NTEXT,
)

ALTER TABLE Categories ADD CONSTRAINT CHK_T_CategoryId
    CHECK (CategoryName IN ('G', 'M' , 'PG') );

SET IDENTITY_INSERT Categories ON
INSERT INTO Categories(Id,CategoryName,Notes)
VALUES(1,'G','TTTT'),
      (2,'M','IIII'),
	  (3,'PG','KKKK'),
	  (4,'M','LLLL'),
	  (5,'M','eLLee')
SET IDENTITY_INSERT Categories OFF
 
CREATE TABLE Movies (
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
CopyrightYear DATE NOT NULL,
[Length] TIME NOT NULL,
Rating INT NOT NULL,
Notes NTEXT
)

ALTER TABLE Movies Add DirectorId INT FOREIGN KEY REFERENCES Directors(Id)
ALTER TABLE Movies Add GenreId INT FOREIGN KEY REFERENCES Genres(Id)
ALTER TABLE Movies Add CategoryId INT FOREIGN KEY REFERENCES Categories(Id)

ALTER TABLE Movies ADD CONSTRAINT Rating_Range_Check
    CHECK(Rating >= 1 and Rating <= 10)

SET IDENTITY_INSERT Movies ON
INSERT INTO Movies(Id,Title,CopyrightYear,[Length],Rating,Notes,DirectorId,GenreId,CategoryId)
VALUES(1,'Matrix','12-08-1999','01:20:23',10,'Fantasy',1,1,1),
      (2,'LOTR','11-03-1981','02:23:23',5,'Adventure',2,2,2),
	  (3,'8 Mile','10-11-1987','03:10:11',7,'Autobiography',3,3,3),
	  (4,'Pitch Black','12-01-1902','01:15:43',4,'Fantasy',4,4,4),
	  (5,'She`s All That','08-12-2003','02:22:12',9,'Comedy,Romance',5,5,5)
	  
------Problem 14.	Car Rental Database

CREATE DATABASE CarRental 

CREATE TABLE Categories  (
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate INT NOT NULL,
WeeklyRate INT NOT NULL,
MonthlyRate INT NOT NULL,
WeekendRate INT NOT NULL
)

SET IDENTITY_INSERT Categories ON
INSERT INTO Categories(Id,CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
VALUES(1,'Motor',2,5,10,6),
      (2,'Truck',5,10,20,11),
	  (3,'Car',4,7,15,10)
	  
SET IDENTITY_INSERT Categories OFF

CREATE TABLE Cars  (
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR(20) NOT NULL,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(30) NOT NULL,
CarYear DATE NOT NULL,
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(30) NOT NULL,
Available BIT NOT NULL
)

ALTER TABLE Cars Add CategoryId INT FOREIGN KEY REFERENCES Categories(Id)

SET IDENTITY_INSERT Cars ON
INSERT INTO Cars(Id,PlateNumber,Manufacturer,Model,CarYear,Doors,Picture,Condition,Available,CategoryId)
VALUES(1,'AL3845US','Ducatti','SS30','09-08-2005',0,NULL,'good',1,1),
      (2,'CL9356US','MAN','Behemoth','12-01-1983',2,NULL,'new',1,2),
	  (3,'NY2034US','VW','Golf','12-08-1999',5,NULL,'bad',0,3)
	  
SET IDENTITY_INSERT Cars OFF

CREATE TABLE Employees   (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NTEXT
)

SET IDENTITY_INSERT Employees ON
INSERT INTO Employees(Id,FirstName,LastName,Title,Notes)
VALUES(1,'John','Doe','Crasher',NULL),
      (2,'Damyan','Bijkov','LSD',NULL),
	  (3,'Sasho','Botev','Mangal',NULL)
	  
SET IDENTITY_INSERT Employees OFF

CREATE TABLE Customers    (
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber NVARCHAR(20) NOT NULL,
FullName NVARCHAR(100) NOT NULL,
[Address] NVARCHAR(30) NOT NULL,
City NVARCHAR(30) NOT NULL,
ZIPCode INT NOT NULL,
Notes NTEXT
)

SET IDENTITY_INSERT Customers ON
INSERT INTO Customers(Id,DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes)
VALUES(1,'12345','Ivan Ivanov','Bojanka str.','Tyrnovo',5000,NULL),
      (2,'23456','Pesho Stamatov','Iliyanka str.','Varna',2345,NULL),
	  (3,'34567','Nikola Armyanov','Marmarliiska str.','Sofia',1232,NULL)
	  
SET IDENTITY_INSERT Customers OFF

CREATE TABLE RentalOrders     (
Id INT PRIMARY KEY IDENTITY,
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays INT NOT NULL,
RateApplied INT NOT NULL,
TaxRate INT NOT NULL,
OrderStatus NVARCHAR(30) NOT NULL,
Notes NTEXT
)

ALTER TABLE RentalOrders ADD CONSTRAINT RateApplied_Range_Check
    CHECK(RateApplied >= 1 and RateApplied <= 10)

ALTER TABLE RentalOrders ADD CONSTRAINT CHK_T_OrderStatus
    CHECK (OrderStatus IN ('Taken', 'Received' , 'Processing') );

ALTER TABLE RentalOrders Add EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
ALTER TABLE RentalOrders Add CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
ALTER TABLE RentalOrders Add CarId INT FOREIGN KEY REFERENCES Cars(Id)

SET IDENTITY_INSERT RentalOrders ON
INSERT INTO RentalOrders(Id,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus,Notes,EmployeeId,CustomerId,CarId)
VALUES(1,20,34000,40000,6000,'08-12-2019','08-22-2019',10,8,10,'Taken',NULL,1,2,3),
      (2,20,20000,60000,40000,'11-10-2020','10-22-2020',10,1,8,'Received',NULL,2,1,2),
	  (3,20,10000,50000,40000,'09-07-2020','07-29-2020',20,9,3,'Processing',NULL,3,3,1)
	  
SET IDENTITY_INSERT RentalOrders OFF


---------Problem 15.Hotel Database

CREATE DATABASE Hotel  

CREATE TABLE Employees   (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NTEXT
)

SET IDENTITY_INSERT Employees ON
INSERT INTO Employees(Id,FirstName,LastName,Title,Notes)
VALUES(1,'Radoslav','Bachurov','BIRS EOOD',NULL),
      (2,'Ivan','Stoev','Metro',NULL),
	  (3,'Nikola','Armyanov','Kukui EOOD',NULL)
	  
SET IDENTITY_INSERT Employees OFF

CREATE TABLE Customers    (
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName  NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber INT NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes NTEXT
)

SET IDENTITY_INSERT Customers ON
INSERT INTO Customers(AccountNumber,FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber,Notes)
VALUES(12345,'Ginka','Peneva',08812321,'Stoicho',08723423,NULL),
      (54321,'Bushido','Topalov',089345345,'Narkos',0835344,NULL),
	  (23456,'Kubrat','Pulev',08734534,'Utaika',08882323,NULL)
	  
SET IDENTITY_INSERT Customers OFF

CREATE TABLE RoomStatus     (
Id INT PRIMARY KEY IDENTITY,
RoomStatus NVARCHAR(50),
Notes NTEXT
)

ALTER TABLE RoomStatus ADD CONSTRAINT CHK_T_RoomStatus
    CHECK (RoomStatus IN ('Cleaned', 'Occupate' , 'ToClean') );

SET IDENTITY_INSERT RoomStatus ON
INSERT INTO RoomStatus(Id,RoomStatus,Notes)
VALUES(1,'Cleaned',NULL),
      (2,'Occupate',NULL),
	  (3,'ToClean',NULL)
	  
SET IDENTITY_INSERT RoomStatus OFF

CREATE TABLE RoomTypes      (
Id INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(50) NOT NULL,
Notes NTEXT
)

ALTER TABLE RoomTypes  ADD CONSTRAINT CHK_T_RoomType
    CHECK (RoomType IN ('VIP', 'Double' , 'Single') );

	SET IDENTITY_INSERT RoomTypes ON
INSERT INTO RoomTypes(Id,RoomType,Notes)
VALUES(1,'VIP',NULL),
      (2,'Double',NULL),
	  (3,'Single',NULL)
	  
SET IDENTITY_INSERT RoomTypes OFF

CREATE TABLE BedTypes      (
Id INT PRIMARY KEY IDENTITY,
BedType NVARCHAR(50) NOT NULL,
Notes NTEXT
)

ALTER TABLE BedTypes  ADD CONSTRAINT CHK_T_BedType
    CHECK (BedType IN ('King', 'Double' , 'Single') );

	SET IDENTITY_INSERT BedTypes ON
INSERT INTO BedTypes(Id,BedType,Notes)
VALUES(1,'King',NULL),
      (2,'Double',NULL),
	  (3,'Single',NULL)
	  
SET IDENTITY_INSERT BedTypes OFF

CREATE TABLE Rooms       (
RoomNumber INT PRIMARY KEY IDENTITY,
Rate INT NOT NULL,
Notes NTEXT
)

ALTER TABLE Rooms ADD CONSTRAINT Rate_Range_Check
    CHECK(Rate >= 1 and Rate <= 10)

ALTER TABLE Rooms Add RoomType INT FOREIGN KEY REFERENCES RoomTypes(Id)
ALTER TABLE Rooms Add BedType INT FOREIGN KEY REFERENCES BedTypes(Id)
ALTER TABLE Rooms Add RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(Id)

SET IDENTITY_INSERT Rooms ON
INSERT INTO Rooms(RoomNumber,Rate,Notes,RoomType,BedType,RoomStatus)
VALUES(1,4,NULL,2,3,3),
      (2,6,NULL,3,1,2),
	  (3,9,NULL,1,2,1)
	  
SET IDENTITY_INSERT Rooms OFF

CREATE TABLE Payments        (
Id INT PRIMARY KEY IDENTITY,
PaymentDate DATE NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays INT NOT NULL,
AmountCharged MONEY NOT NULL,
TaxRate INT NOT NULL,
TaxAmount MONEY NOT NULL,
PaymentTotal MONEY NOT NULL,
Notes NTEXT
)

ALTER TABLE Payments Add EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
ALTER TABLE Payments Add AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber)

SET IDENTITY_INSERT Payments ON
INSERT INTO Payments(Id,PaymentDate,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal,Notes,EmployeeId,AccountNumber)
VALUES(1,'08-12-2019','03-12-2019','08-10-2019',21,351.43,10,53.234,233.43,NULL,3,54321),
      (2,'09-11-2020','08-06-2019','03-22-2019',10,243.45,11,15.32,345.43,NULL,1,12345),
	  (3,'04-09-2018','06-10-2018','01-02-2019',11,333.11,15,23.34,348.4,NULL,2,23456)
	  
SET IDENTITY_INSERT Payments OFF

CREATE TABLE Occupancies         (
Id INT PRIMARY KEY IDENTITY,
PhoneCharge INT NOT NULL,
Notes NTEXT
)

ALTER TABLE Occupancies Add EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
ALTER TABLE Occupancies Add DateOccupied INT FOREIGN KEY REFERENCES Payments(Id)
ALTER TABLE Occupancies Add AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber)
ALTER TABLE Occupancies Add RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber)
ALTER TABLE Occupancies Add RateApplied INT FOREIGN KEY REFERENCES Rooms(RoomNumber)

SET IDENTITY_INSERT Occupancies ON
INSERT INTO Occupancies(Id,PhoneCharge,Notes,EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied)
VALUES(1,43,NULL,3,2,54321,1,1),
      (2,22,NULL,1,1,12345,2,2),
	  (3,100,NULL,2,3,23456,3,3)
	  
SET IDENTITY_INSERT Occupancies OFF


--------Problem 16.	Create SoftUni Database

CREATE DATABASE SoftUni

CREATE TABLE Towns          (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(40) NOT NULL
)

INSERT INTO Towns([Name])
VALUES('Sofia'),
      ('Plovdiv'),
	  ('Varna'),
	  ('Burgas')

CREATE TABLE Addresses           (
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(80) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments           (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

INSERT INTO Departments ([Name])
VALUES('Engineering'),
      ('Sales'),
      ('Marketing'),
      ('Software Development'),
      ('Quality Assurance')

CREATE TABLE Employees            (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(40) NOT NULL,
MiddleName NVARCHAR(40),
LastName NVARCHAR(40),
JobTitle NVARCHAR(40) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE NOT NULL,
Salary MONEY NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Employees (FirstName,JobTitle,DepartmentId,HireDate,Salary)
VALUES('Ivan Ivanov Ivanov'	,'.NET Developer',4,'02-01-2013',3500.00),
      ('Petar Petrov Petrov','Senior Engineer',1,'03-02-2004',4000.00),
      ('Maria Petrova Ivanova','Intern',5,'08-28-2016',525.25),
      ('Georgi Teziev Ivanov','CEO',2,'12-09-2007',3000.00),
      ('Peter Pan Pan','Intern',3,'08-28-2016',599.88)

SELECT * FROM Towns
ORDER BY [Name]
SELECT * FROM Departments
ORDER BY [Name]
SELECT * FROM Employees
ORDER BY Salary DESC

SELECT [Name] FROM Towns
ORDER BY [Name]
SELECT [Name] FROM Departments
ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees

UPDATE Payments
SET TaxRate  = TaxRate  * 0.97;
SELECT TaxRate FROM Payments

TRUNCATE TABLE Occupancies 

