---1
SELECT FirstName,LastName
FROM Employees
WHERE FirstName LIKE 'sa%'

---2
SELECT FirstName,LastName
FROM Employees
WHERE LastName LIKE '%ei%'

---3

SELECT FirstName
FROM Employees
WHERE YEAR(HireDate) BETWEEN  1995 AND 2005 AND DepartmentID IN (3,10) 

---4

SELECT FirstName,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%ENGINEER%'

---5

SELECT [Name]
FROM 
	Towns
WHERE 
	LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY
	[Name]

---6
--M, K, B or E.
SELECT TownID,[Name]
FROM 
	Towns
WHERE 
	CHARINDEX ( 'M', [Name] ) = 1 OR
	CHARINDEX ( 'K', [Name] ) = 1 OR
	CHARINDEX ( 'B', [Name] ) = 1 OR
	CHARINDEX ( 'E', [Name] ) = 1 
ORDER BY
	[Name]

---7
SELECT TownID,[Name]
FROM 
	Towns
WHERE 
	CHARINDEX ( 'R', [Name] ) != 1 AND
	CHARINDEX ( 'B', [Name] ) != 1 AND
	CHARINDEX ( 'D', [Name] ) != 1 
ORDER BY
	[Name]

---8

CREATE VIEW V_EmployeesHiredAfter2000  AS
SELECT 
	FirstName,LastName
FROM 
	Employees
WHERE 
	YEAR(HireDate) > 2000

	
---9
SELECT 
	FirstName,LastName
FROM 
	Employees
WHERE 
	LEN(LastName) = 5

---10

SELECT 
	EmployeeID,FirstName,LastName,Salary,DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM 
	Employees
WHERE
	Salary BETWEEN 10000 AND 50000 
ORDER BY
	Salary DESC
	
---11
SELECT * FROM (
SELECT 
	EmployeeID,FirstName,LastName,Salary,DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM 
	Employees
WHERE
	Salary BETWEEN 10000 AND 50000 ) AS MyTable 
WHERE 
	MyTable.Rank = 2
ORDER BY
	Salary DESC

---12

SELECT 
	CountryName,IsoCode
FROM 
	Countries
WHERE 
	CountryName LIKE '%a%a%a%'
ORDER BY 
	IsoCode

---13

SELECT 
	PeakName,RiverName,LOWER (PeakName + SUBSTRING (RiverName,2, LEN(RiverName))  ) AS Mix
FROM 
	Peaks,Rivers
WHERE
	RIGHT ( PeakName , 1 )  = LEFT ( RiverName , 1 )  
ORDER BY Mix

---14

SELECT TOP(50)
	[Name],FORMAT ( [Start], 'yyyy-MM-dd' ,'en-US' )  AS [Start]
FROM 
	Games
WHERE 
	YEAR([Start]) IN (2011,2012)
ORDER BY
	[Start],[Name]
	
---15

SELECT 
	Username , SUBSTRING(Email , CHARINDEX ( '@' , Email ) + 1 , LEN(Email)) AS 'Email Provider'
FROM 
	Users
ORDER BY [Email Provider],Username

---16

SELECT 
	Username , IpAddress
FROM 
	Users
WHERE
	IpAddress LIKE '___.1_%._%.___'
ORDER BY 
	Username


---17

SELECT 
	[Name] AS 'Game',
	CASE
    WHEN DATEPART (HOUR,[Start]) >= 0 AND DATEPART (HOUR,[Start]) < 12 THEN 'Morning'
    WHEN DATEPART (HOUR,[Start]) >= 12 AND DATEPART (HOUR,[Start]) < 18 THEN 'Afternoon'
    ELSE 'Evening' 
END AS 'Part of the Day',
CASE
    WHEN Duration <= 3 THEN 'Extra Short'
    WHEN Duration >= 4 AND  Duration <= 6 THEN 'Short'
	WHEN Duration > 6  THEN 'Long'
    ELSE 'Extra Long' 
END AS 'Duration'

FROM 
	Games
ORDER BY 
	[Name],Duration,[Part of the Day]
	
---18

SELECT 
	ProductName,OrderDate,DATEADD(DAY, 3, OrderDate) AS 'Pay Due',DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
FROM 
	Orders


---19

CREATE TABLE People (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50),
    Birthday DATETIME,
  );

INSERT INTO People ([Name],Birthday)
VALUES  ('Ivan Stoev','12-08-1987'),
		('Nikola Peev','11-04-1956'),
		('Delqn Peevski','09-02-1995')

SELECT 
	[Name],Birthday,DATEDIFF ( YEAR , Birthday , GETDATE() ) AS Age
FROM 
	People
ORDER BY
	Age