-----1
CREATE TABLE Users (
   Id INT PRIMARY KEY IDENTITY
   ,Username VARCHAR(30) UNIQUE NOT NULL
   ,Password VARCHAR(50) NOT NULL
   ,Name VARCHAR(50) 
   ,Birthdate DATETIME 
   ,Age INT
   ,CONSTRAINT CHK_Age CHECK (Age>=14 AND Age<=110)
   ,Email VARCHAR(50) NOT NULL
);

CREATE TABLE Departments (
   Id INT PRIMARY KEY IDENTITY
   ,Name VARCHAR(50) NOT NULL
);

CREATE TABLE Employees (
   Id INT PRIMARY KEY IDENTITY
   ,FirstName VARCHAR(30) 
   ,LastName VARCHAR(25)
   ,Birthdate DATETIME
   ,Age INT 
   ,CONSTRAINT CHK_EmAge CHECK (Age>=18 AND Age<=110)
   ,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
);

CREATE TABLE Categories (
   Id INT PRIMARY KEY IDENTITY
   ,Name VARCHAR(50)  NOT NULL
   ,DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
);

CREATE TABLE Status (
   Id INT PRIMARY KEY IDENTITY
   ,Label VARCHAR(30) NOT NULL
);

CREATE TABLE Reports (
   Id INT PRIMARY KEY IDENTITY
   ,CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
   ,StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id)
   ,OpenDate DATETIME NOT NULL
   ,CloseDate DATETIME 
   ,Description VARCHAR(200) NOT NULL
   ,UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
   ,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
   );

 -----2
 INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId)
VALUES('Marlo',	'O''Malley','1958-9-21',1),
('Niki','Stanaghan','1969-11-26',4),
('Ayrton','Senna','1960-03-21',	9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)

 INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId)
VALUES(1,1,'2017-04-13'	,NULL,'Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07',NULL,'Falling bricks on Str.58'	,5,	2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

 -----3
 UPDATE Reports
 SET CloseDate = GETDATE() 
 WHERE CloseDate IS NULL

 -----4
 DELETE FROM Reports WHERE StatusId=4;

  -----5
SELECT
	Description,FORMAT (OpenDate, 'dd-MM-yyyy ') as OpenDate
FROM
	Reports
WHERE
	EmployeeId IS NULL
ORDER BY
	YEAR(OpenDate),MONTH(OpenDate),DAY(OpenDate),Description

----6
SELECT
	Description,c.Name
FROM
	Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id
WHERE
	CategoryId IS NOT NULL
ORDER BY
	Description,c.Name

-----7
SELECT TOP 5
	c.Name,COUNT(c.Name) AS ReportsNumber
FROM
	Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY
	c.Name
ORDER BY
	ReportsNumber DESC ,C.Name

-----8
SELECT 
	u.Username,c.Name
FROM
	Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id
	JOIN Users AS u ON u.Id = r.UserId
WHERE
	DAY(r.OpenDate) = DAY(u.Birthdate)
        AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY
	u.Username,c.Name

-------9
SELECT 
	e.FirstName + ' ' + e.LastName AS FullName , COUNT(r.EmployeeId) AS UsersCount
FROM
	Reports AS r RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
GROUP BY
	e.FirstName + ' ' + e.LastName,r.EmployeeId
ORDER BY
	UsersCount DESC,FullName
	
-------10

SELECT
	   IIF(CONCAT(e.FirstName, ' ', e.LastName) = '', 'None',  CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee],
       IIF(d.Name IS NULL, 'None', d.Name) AS [Department],
       c.Name AS [Category],
       r.Description,
       FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
       s.Label AS [Status],
       u.Name AS [User]
FROM
	Reports AS r LEFT JOIN Users AS u ON r.UserId = u.Id
	LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
	LEFT JOIN Categories AS c ON r.CategoryId = c.Id
	LEFT JOIN Status AS s ON r.StatusId = s.Id
	LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
ORDER BY
	e.FirstName DESC,e.LastName DESC,d.Name,c.Name,r.Description,r.OpenDate,s.Id,u.Id

-------11
go
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT   
AS   
BEGIN  
IF(@StartDate IS NULL OR @EndDate IS NULL)  
	BEGIN
	RETURN 0;
	END

DECLARE @diff INT = DATEDIFF(HOUR, @StartDate, @EndDate)
RETURN @diff
END; 

-------12
go
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @EmD VARCHAR(MAX) = (SELECT TOP 1 d.Name FROM Employees AS e JOIN Departments AS d ON e.DepartmentId = d.Id WHERE e.Id = @EmployeeId)
DECLARE @ReD VARCHAR(MAX) = (SELECT TOP 1 d.Name FROM Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id JOIN Departments AS d ON c.DepartmentId = d.Id WHERE r.Id = @ReportId)

IF(@EmD = @ReD) 
	BEGIN
	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId;
	END
ELSE
	RAISERROR ('Employee doesn''t belong to the appropriate department!',16,1)