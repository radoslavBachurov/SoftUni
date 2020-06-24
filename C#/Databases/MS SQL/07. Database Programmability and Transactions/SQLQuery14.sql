----1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
SELECT FirstName,LastName FROM Employees WHERE Salary > 35000

----2

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
SELECT FirstName,LastName FROM Employees WHERE Salary >= @Number

----3

CREATE PROCEDURE usp_GetTownsStartingWith @Starts VARCHAR(80)
AS
SELECT @Starts = RTRIM(@Starts) + '%';
SELECT [Name] FROM Towns WHERE [Name] LIKE @Starts

----4

CREATE PROCEDURE usp_GetEmployeesFromTown  @TName VARCHAR(80)
AS
SELECT 
	FirstName,LastName 
FROM 
	Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
WHERE
	@TName = t.[Name]

-----5

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(20)
AS
BEGIN
DECLARE @LEVEL VARCHAR(20)  

IF @Salary < 30000
	SET @LEVEL = 'Low'
ELSE IF @Salary >= 30000 AND @Salary <= 50000
	SET @LEVEL = 'Average'
ELSE IF @Salary > 50000
	SET @LEVEL = 'High'

RETURN @LEVEL
END

-----6

CREATE PROCEDURE usp_EmployeesBySalaryLevel   @Level VARCHAR(20)
AS

SELECT
	FirstName,LastName
FROM
	Employees
WHERE
	dbo.ufn_GetSalaryLevel(Salary) = @Level


----7

CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(100), @word VARCHAR(100))
RETURNS BIT
AS
BEGIN
DECLARE @Count INT = 1;
	WHILE (CHARINDEX(SUBSTRING(@word,@Count,1),@setOfLetters) > 0)
		BEGIN  
		
			IF (@Count = LEN(@word))
			BEGIN
				RETURN 1
			END
	
			SET @Count += 1
		
		END  
RETURN 0
END


----8

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
ALTER TABLE 
	Departments
ALTER COLUMN 
	ManagerID INT 

DELETE FROM
	EmployeesProjects 
WHERE 
	EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId);

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId;

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId);

DELETE FROM Employees WHERE DepartmentID = @departmentId;
DELETE FROM Departments WHERE DepartmentID = @departmentId;

SELECT COUNT(EmployeeID) FROM Employees WHERE DepartmentID = @departmentId

----9

CREATE PROCEDURE usp_GetHoldersFullName    
AS
SELECT
	(FirstName+' '+LastName) AS 'Full Name'
FROM
	AccountHolders

-----10

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number MONEY)    
AS
SELECT
	FirstName,LastName
FROM
	AccountHolders as a JOIN Accounts AS acc ON acc.AccountHolderId = a.Id
GROUP BY 
	FirstName,LastName,AccountHolderId
HAVING
	SUM(acc.Balance)>@number
ORDER BY
	FirstName,LastName

------11

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(34,4) , @yearlyIntrest FLOAT , @numberYears INT)
RETURNS DECIMAL(34,4)
AS
BEGIN
DECLARE @returnValue DECIMAL(34,4)  
SET @returnValue = @sum * ( POWER(1 + @yearlyIntrest,@numberYears))
RETURN @returnValue
END
	
------12

CREATE PROCEDURE usp_CalculateFutureValueForAccount  (@accountId INT,@interestRate FLOAT)    
AS

SELECT 
	 acc.Id AS 'Account Id' 
	,a.FirstName AS 'First Name' 
	,a.LastName AS 'Last Name' 
	,acc.Balance AS 'Current Balance' 
	,dbo.ufn_CalculateFutureValue(CAST(acc.Balance AS decimal(34,4)),@interestRate,5) AS 'Balance in 5 years' 
FROM 
	AccountHolders AS a JOIN Accounts AS acc ON acc.AccountHolderId = a.Id
WHERE 
	acc.Id = @accountId
	
-------13
CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(90))
RETURNS TABLE
AS
RETURN
(SELECT 
     SUM(mt.Cash) AS 'SumCash'
FROM
	(SELECT 
		ug.Cash,ROW_NUMBER() OVER (Order by ug.Cash DESC) AS 'RowNumber'
	FROM 
		Games AS g JOIN UsersGames AS ug ON g.id = ug.GameId
	WHERE 
		g.[Name] = @gameName) AS mt
WHERE
	mt.RowNumber % 2 != 0)
	
SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

-------14
CREATE TABLE Logs (
    LogId INT PRIMARY KEY IDENTITY,
    AccountId INT,
    OldSum MONEY,
    NewSum MONEY
);

CREATE TRIGGER tr_BalanceChanges
ON Accounts
FOR UPDATE
AS
BEGIN
INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT i.Id,d.Balance,i.Balance FROM inserted AS i JOIN deleted AS d ON i.Id = d.Id
END

------15
CREATE TABLE NotificationEmails (
    Id INT PRIMARY KEY IDENTITY,
    Recipient INT,
    [Subject] NVARCHAR(MAX),
    Body NVARCHAR(MAX)
);

CREATE TRIGGER tr_TableEmails
ON Logs
FOR INSERT
AS
BEGIN
INSERT INTO NotificationEmails (Recipient, [Subject], Body)
SELECT i.AccountId,'Balance change for account: ' + Convert(varchar(50), i.AccountId),'On '+ Convert(varchar(50), GETDATE()) +' your balance was changed from '+Convert(varchar(50), i.OldSum)+' to '+Convert(varchar(50), i.NewSum)+'.'
FROM inserted AS i
END

UPDATE Accounts
SET Balance += 100
where AccountHolderId = 2


-----16

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4)) 
AS
UPDATE Accounts
SET Balance += @MoneyAmount
WHERE Id = @AccountId



-----17

CREATE PROCEDURE usp_WithdrawMoney  (@AccountId INT, @MoneyAmount DECIMAL(18,4)) 
AS
UPDATE Accounts
SET Balance -= @MoneyAmount
WHERE Id = @AccountId AND Balance >= @MoneyAmount



-----18

CREATE PROCEDURE usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN TRANSACTION
DECLARE @Sender INT = (SELECT Id FROM Accounts WHERE id = @SenderId)
DECLARE @Receiver INT = (SELECT Id FROM Accounts WHERE id = @ReceiverId)
DECLARE @currAmount MONEY = (SELECT Balance FROM Accounts WHERE id = @SenderId)

IF(@Sender IS NULL OR @Receiver IS NULL)
	BEGIN
	ROLLBACK
	RAISERROR('Sender or receiver are null',16,1)
	RETURN
	END

IF(@currAmount<@Amount)
	BEGIN
	ROLLBACK
	RAISERROR('Not enought money',16,2)
	RETURN
	END

EXEC dbo.usp_DepositMoney @ReceiverId,@Amount
EXEC dbo.usp_WithdrawMoney @SenderId,@Amount
COMMIT

EXEC dbo.usp_TransferMoney 1,2,100


-----21
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
DECLARE @countProjects INT = (SELECT COUNT(EmployeeID) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

IF(@countProjects>=3)
BEGIN
ROLLBACK
RAISERROR('The employee has too many projects!',16,1)
RETURN
END

INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
VALUES (@emloyeeId,@projectID)
COMMIT

EXEC dbo.usp_AssignProject 224,4

-----22

--Deleted_Employees(EmployeeId PK, FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary) 

CREATE TABLE Deleted_Employees(
EmployeeId INT PRIMARY KEY ,
FirstName VARCHAR(MAX),
LastName VARCHAR(MAX),
MiddleName VARCHAR(MAX),
JobTitle VARCHAR(MAX),
DepartmentId INT,
Salary MONEY
)

CREATE TRIGGER Delete_log   
ON Employees
FOR DELETE
AS
INSERT INTO Deleted_Employees
SELECT FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary FROM deleted

DELETE FROM Employees WHERE EmployeeID=1;
