----1
CREATE TABLE Students (
   Id INT PRIMARY KEY IDENTITY
   ,FirstName NVARCHAR(30) NOT NULL
   ,MiddleName NVARCHAR(25)
   ,LastName NVARCHAR(30) NOT NULL
   ,Age INT 
   ,CONSTRAINT CHK_Age CHECK (Age>=5 AND Age<=100)
   ,[Address] NVARCHAR(50)
   ,Phone CHAR(10)
);

CREATE TABLE Subjects (
   Id INT PRIMARY KEY IDENTITY
   ,[Name] NVARCHAR(20) NOT NULL
   ,Lessons INT NOT NULL
   ,CONSTRAINT CHK_Lessons CHECK (Lessons>0)
);

CREATE TABLE StudentsSubjects (
   Id INT PRIMARY KEY IDENTITY
   ,StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id)
   ,SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
   ,Grade DECIMAL(18,2) NOT NULL
   ,CONSTRAINT CHK_Grade CHECK (Grade>=2 AND Grade<=6)
);

CREATE TABLE Exams (
   Id INT PRIMARY KEY IDENTITY
   ,[Date] DATETIME 
   ,SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
);

CREATE TABLE StudentsExams (
    StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id)
   ,ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id)
   ,Grade DECIMAL(18,2)
   ,CONSTRAINT CHK_GradeExam CHECK (Grade>=2 AND Grade<=6)
   ,CONSTRAINT StudentIdExamId PRIMARY KEY (StudentId, ExamId)
);

CREATE TABLE Teachers (
    Id INT PRIMARY KEY IDENTITY
   ,FirstName NVARCHAR(20) NOT NULL
   ,LastName NVARCHAR(20) NOT NULL
   ,[Address] NVARCHAR(20) NOT NULL
   ,Phone CHAR(10)
   ,SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
   
);

CREATE TABLE StudentsTeachers (
    StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id)
   ,TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id)
   ,CONSTRAINT StudentIdTeacherId PRIMARY KEY (StudentId, TeacherId)
);

----2
INSERT INTO Teachers(FirstName,LastName,Address,Phone,SubjectId)
VALUES('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard',	'Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)

INSERT INTO Subjects([Name],Lessons)
VALUES
('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

----3
UPDATE 
	StudentsSubjects 
SET 
	Grade = 6.00
WHERE
	(SubjectId = 1 OR SubjectId = 2) AND Grade >= 5.50

-----4

DELETE FROM StudentsTeachers WHERE TeacherId IN( SELECT Id FROM Teachers WHERE Phone LIKE ('%72%'))
DELETE FROM Teachers WHERE Phone LIKE ('%72%')

------5
SELECT
	FirstName,LastName,Age
FROM
	Students
WHERE
	Age>=12
ORDER BY
	FirstName,LastName

----6
SELECT
	s.FirstName,s.LastName,COUNT(s.Id) AS 'TeachersCount'
FROM
	Students AS s JOIN StudentsTeachers AS t ON t.StudentId = s.Id
GROUP BY
	s.FirstName,s.LastName

----7
SELECT
	s.FirstName + ' ' + s.LastName AS 'Full Name'
FROM
	Students AS s LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE 
	se.ExamId IS NULL
ORDER BY
	[Full Name]

----8
SELECT TOP 10
	s.FirstName , s.LastName , CAST(AVG(se.Grade) AS DECIMAL(10,2)) AS 'Grade'
FROM
	Students AS s LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY
	s.FirstName , s.LastName 
ORDER BY	
	Grade DESC,FirstName,LastName

----9
SELECT
	FirstName + ISNULL(' ' + MiddleName + ' ', ' ') + LastName AS 'Full Name'
FROM	
	Students AS s LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE 
	ss.SubjectId IS NULL
ORDER BY 
	[Full Name]
	
-----10
SELECT
	s.Name,AVG(Grade) AS 'AverageGrade'
FROM
	Subjects AS s JOIN StudentsSubjects AS ss ON s.Id=ss.SubjectId
GROUP BY
	s.Name,ss.SubjectId
ORDER BY 
	ss.SubjectId

----11

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,2))
RETURNS VARCHAR(MAX)
AS   
BEGIN 

DECLARE @nonExistingStudent VARCHAR(MAX) = 'The student with provided id does not exist in the school!'
DECLARE @invalidGrade VARCHAR(MAX) = 'Grade cannot be above 6.00!'
DECLARE @studentExist VARCHAR(MAX) = (SELECT TOP 1 FirstName FROM Students WHERE Id = @studentId)

IF(@grade > 6)
	BEGIN
	RETURN @invalidGrade
	END

IF(@studentExist IS NULL)
	BEGIN
	RETURN @nonExistingStudent
	END

DECLARE @count INT = (SELECT COUNT(S.Id)
					  FROM Students AS s LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId 
					  WHERE s.Id = @studentId AND ss.Grade>@grade AND ss.Grade<=(@grade+0.5)
					  GROUP BY S.Id)

DECLARE @succesMessage VARCHAR(MAX) = 'You have to update ' + CAST ( @count AS VARCHAR(MAX)) + ' grades for the student ' + @studentExist
RETURN @succesMessage
END

----12
go
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
DECLARE @errMessage VARCHAR(MAX) = 'This school has no student with the provided id!'
DECLARE @studentExists INT = (SELECT TOP 1 Id FROM Students WHERE id=@StudentId)

IF(@studentExists IS NULL)
	BEGIN
	RAISERROR ('This school has no student with the provided id!',16,1) 
	END

DELETE FROM StudentsSubjects WHERE StudentId = @StudentId
DELETE FROM StudentsExams WHERE StudentId = @StudentId
DELETE FROM StudentsTeachers WHERE StudentId = @StudentId
DELETE FROM Students WHERE Id = @StudentId
END

