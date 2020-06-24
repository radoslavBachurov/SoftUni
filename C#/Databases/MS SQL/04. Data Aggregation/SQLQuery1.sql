---1
SELECT
	COUNT(Id) AS [COUNT]
FROM
	WizzardDeposits

---2
SELECT
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM
	WizzardDeposits

---3
SELECT
	DepositGroup,
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM
	WizzardDeposits
GROUP BY 
	DepositGroup

---4
SELECT TOP(2)
	DepositGroup
FROM
	WizzardDeposits
GROUP BY 
	DepositGroup
ORDER BY 
	AVG(MagicWandSize)

---5
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM
	WizzardDeposits
GROUP BY 
	DepositGroup

---6
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM
	WizzardDeposits
WHERE
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup

---7
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM
	WizzardDeposits
WHERE
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup
HAVING
	SUM(DepositAmount)<150000
ORDER BY
	TotalSum DESC

---8
SELECT 
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge)
FROM
	WizzardDeposits
GROUP BY 
	DepositGroup,MagicWandCreator
	
---9
SELECT 
	AgeRank.AgeGroup AS AgeGroup,COUNT(AgeRank.AgeGroup)
FROM
	(SELECT 
	CASE
		WHEN Age >=0 AND Age <=10 THEN '[0-10]'
	    WHEN Age >=11 AND Age <=20  THEN '[11-20]'
		WHEN Age >=21 AND Age <=30  THEN '[21-30]'
		WHEN Age >=31 AND Age <=40  THEN '[31-40]'
		WHEN Age >=41 AND Age <=50  THEN '[41-50]'
		WHEN Age >=51 AND Age <=60  THEN '[51-60]'
		ELSE '[61+]'
	END AS 
		AgeGroup
	FROM 
		WizzardDeposits) AS AgeRank
GROUP BY
	AgeGroup 

---10
SELECT
	SUBSTRING ( FirstName ,1 , 1 ) AS FirstLetter
FROM 
	WizzardDeposits
WHERE
	DepositGroup = 'Troll Chest'
GROUP BY 
	SUBSTRING ( FirstName ,1 , 1 )

---11

SELECT
	DepositGroup,IsDepositExpired,AVG(DepositInterest)
FROM 
	WizzardDeposits
WHERE
	DepositStartDate > '01/01/1985'
GROUP BY
	DepositGroup,IsDepositExpired
ORDER BY	
	DepositGroup DESC,IsDepositExpired

---12
SELECT
	SUM(k.diff) AS 'SumDifference'
FROM
	(SELECT
		DepositAmount - (SELECT DepositAmount FROM WizzardDeposits AS w WHERE w.Id = wd.Id+1) AS 'diff'
	FROM 
		WizzardDeposits AS wd) AS k

---13

SELECT
	DepartmentID,SUM(Salary)
FROM 
	Employees
GROUP BY
	DepartmentID
ORDER BY	
	DepartmentID

---14
SELECT
	DepartmentID,MIN(Salary)
FROM 
	Employees
WHERE
	DepartmentID IN(2,5,7) AND HireDate >= Convert(datetime, '01/01/2000' )
GROUP BY
	DepartmentID

---15
SELECT
	* INTO NewTable
FROM 
	Employees
WHERE
	Salary > 30000 

DELETE FROM 
	NewTable
WHERE 
	ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID=1;

SELECT
	DepartmentID,AVG(Salary) AS 'Average Salary'
FROM 
	NewTable
GROUP BY
	DepartmentID

---16

SELECT
	DepartmentID,MAX(Salary) AS 'MaxSalary'
FROM 
	Employees
GROUP BY
	DepartmentID
HAVING 
	MAX(Salary) NOT BETWEEN 30000  AND 70000

---17
SELECT
	COUNT(Salary)
FROM 
	Employees
WHERE 
	ManagerID IS NULL

---18

SELECT DISTINCT 
	DepartmentID,Salary AS 'ThirdHighestSalary'
FROM
	(SELECT
		*,DENSE_RANK ( ) OVER ( PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
	FROM 
		Employees) AS NewTable
WHERE 
	NewTable.Rank = 3

---19
SELECT TOP(10)
	FirstName,LastName,Employees.DepartmentID
FROM
	(SELECT 
		DepartmentID,AVG(Salary) AS 'AvgSalary'
	FROM 
		Employees
	GROUP BY
		DepartmentID) AS MyTable,Employees
WHERE
	Employees.Salary > MyTable.AvgSalary AND MyTable.DepartmentID = Employees.DepartmentID
ORDER BY 
	Employees.DepartmentID

------------------------------------------------------------------------------------------------------
SELECT TOP(10)
	FirstName,LastName,DepartmentID
FROM
	Employees AS em
WHERE
	em.Salary > (SELECT AVG(Salary) FROM Employees as m WHERE m.DepartmentID=em.DepartmentID)
ORDER BY 
	em.DepartmentID