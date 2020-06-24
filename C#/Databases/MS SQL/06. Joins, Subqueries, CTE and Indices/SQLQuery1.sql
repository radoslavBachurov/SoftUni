-----1

SELECT TOP 5
	e.EmployeeID,e.JobTitle,a.AddressID,a.AddressText
FROM
	Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY
	a.AddressID

----2

SELECT TOP 50
	e.FirstName,e.LastName,t.[Name],a.AddressText
FROM
	Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns as t ON a.TownID = t.TownID
ORDER BY
	e.FirstName,e.LastName

----3
SELECT 
	e.EmployeeID,e.FirstName,e.LastName,d.[Name] AS 'DepartmentName'
FROM
	Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY
	e.EmployeeID

----4

SELECT TOP 5
	e.EmployeeID,e.FirstName,e.Salary,d.[Name] AS 'DepartmentName'
FROM
	Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND e.Salary > 15000
ORDER BY
	e.DepartmentID

----5
SELECT TOP 3
	e.EmployeeID,e.FirstName 
FROM
	Employees AS e LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE 
	ep.EmployeeID IS NULL
ORDER BY
	e.EmployeeID

----6
SELECT 
	e.FirstName,e.LastName,e.HireDate,d.[Name] AS DeptName
FROM
	Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND HireDate > '1999-01-01'
WHERE 
	d.[Name] IN ('Sales','Finance')
ORDER BY
	e.HireDate

----7
SELECT TOP 5
	e.EmployeeID,e.FirstName,p.[Name] AS 'ProjectName'
FROM
	Employees AS e JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID 
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE 
	p.StartDate>'2002-08-13' AND p.EndDate IS NULL
ORDER BY
	EmployeeID

----8
SELECT 
	e.EmployeeID,e.FirstName,
	CASE
    WHEN YEAR(p.StartDate) >= 2005 THEN NULL
    ELSE p.Name
END AS ProjectName
FROM
	Employees AS e JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID AND e.EmployeeID = 24
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID

----9
SELECT
	EmployeeID,FirstName,ManagerID,(SELECT FirstName FROM Employees AS em WHERE e.ManagerID = em.EmployeeID) AS 'ManagerName'
FROM
	Employees AS e
WHERE
	e.ManagerID IN (3,7)
ORDER BY
	e.EmployeeID

------10
SELECT TOP 50
	EmployeeID
	,FirstName + ' ' + LastName AS 'EmployeeName'
	,(SELECT FirstName + ' ' + LastName FROM Employees AS em WHERE e.ManagerID = em.EmployeeID) AS 'ManagerName'
	,d.Name AS 'DepartmentName'
	
FROM
	Employees AS e JOIN Departments as d ON e.DepartmentID = d.DepartmentID
ORDER BY
	e.EmployeeID

----11
SELECT TOP 1
	AVG(Salary) AS 'MinAverageSalary'
FROM
	Employees 
GROUP BY 
	DepartmentID
ORDER BY
	MinAverageSalary 

----12
SELECT
	mc.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode AND C.CountryName = 'Bulgaria'
	JOIN Mountains AS m ON mc.MountainId = m.Id
	JOIN Peaks as p ON p.MountainId = m.Id AND p.Elevation > 2835
ORDER BY 
	Elevation DESC

----13
SELECT
	mc.CountryCode AS 'cc',COUNT(mc.CountryCode ) AS 'MountainRanges'
FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode AND C.CountryName IN ('Bulgaria','Russia','United States')
GROUP BY
	mc.CountryCode 
ORDER BY 
	MountainRanges DESC

----14
SELECT TOP 5
	c.CountryName,r.RiverName
FROM Countries AS c
    LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	JOIN Continents AS cn ON cn.ContinentCode = c.ContinentCode AND ContinentName = 'Africa'
Order BY 
	c.CountryName

----15
SELECT
	mt.ContinentCode,mt.CurrencyCode,mt.[Count] AS 'CurrencyUsage'
FROM
    (SELECT
		ContinentCode,CurrencyCode,COUNT(CurrencyCode) AS 'Count',
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS 'Rank'
	FROM
		Countries
	GROUP BY
		ContinentCode,CurrencyCode
	HAVING COUNT(CurrencyCode) > 1) AS mt
WHERE
	mt.[Rank] = 1
ORDER BY	
		mt.ContinentCode

----16
SELECT
    COUNT(mt.IsMountain)
FROM
	(SELECT
		CASE
		WHEN MountainId IS NULL THEN '1'
		ELSE '0'
		END AS IsMountain
	FROM
		Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode) AS mt
WHERE MT.IsMountain = '1'

---17
WITH CountryElevation_CTE
(CountryName,Elevation)
AS
(SELECT
	mt.CountryName,mt.Elevation
FROM
    (SELECT
		CountryName,p.Elevation,
		DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY p.Elevation DESC) AS 'Rank'
	 FROM
		Countries AS c LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains as m ON mc.MountainId = m.Id
		LEFT JOIN Peaks as p ON m.Id = p.MountainId) AS mt
WHERE 
	mt.[Rank] = 1
)

SELECT TOP 5
	rt.CountryName,ce.Elevation AS 'HighestPeakElevation',rt.[Length] AS 'LongestRiverLength' 
FROM
    (SELECT
		CountryName,r.[Length],
		DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY r.[Length] DESC) AS 'Rank'
	FROM
		Countries AS c LEFT JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers as r ON cr.RiverId = r.Id) AS rt 
		JOIN CountryElevation_CTE AS ce ON ce.CountryName = rt.CountryName
WHERE 
	rt.[Rank] = 1
ORDER BY
  HighestPeakElevation DESC , LongestRiverLength DESC , rt.CountryName

  ---------------------
  --------------------
SELECT TOP 5
	c.CountryName,MAX(p.Elevation) AS 'HighestPeakElevation',MAX(r.[Length]) AS 'LongestRiverLength' 
FROM
	Countries AS c LEFT JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers as r ON cr.RiverId = r.Id 
	LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains as m ON mc.MountainId = m.Id
	LEFT JOIN Peaks as p ON m.Id = p.MountainId
GROUP BY
	c.CountryName
ORDER BY
  HighestPeakElevation DESC , LongestRiverLength DESC , c.CountryName
	

------18

SELECT TOP 5
	mt.CountryName
	,ISNULL(mt.PeakName, '(no highest peak)') AS 'Highest Peak Name' 
	,ISNULL(mt.Elevation, '0') AS 'Highest Peak Elevation' 
	,ISNULL(mt.MountainRange, '(no mountain)') AS 'Mountain' 
FROM
    (SELECT
		CountryName,p.Elevation,m.MountainRange,p.PeakName,
		DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY p.Elevation DESC) AS 'Rank'
	 FROM
		Countries AS c LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains as m ON mc.MountainId = m.Id
		LEFT JOIN Peaks as p ON m.Id = p.MountainId ) AS mt
WHERE 
	mt.[Rank] = 1
ORDER BY
	mt.CountryName,[Highest Peak Name]

	


