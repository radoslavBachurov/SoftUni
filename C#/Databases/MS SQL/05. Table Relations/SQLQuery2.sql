---1
CREATE TABLE Passports (
    PassportID INT NOT NULL PRIMARY KEY,
    PassportNumber VARCHAR(40),
  );


CREATE TABLE Persons (
    PersonId INT NOT NULL,
    FirstName VARCHAR(40),
    Salary INT,
    PassportID INT UNIQUE,
	CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID)
    REFERENCES Passports(PassportID)
);

ALTER TABLE Persons
ADD PRIMARY KEY (PersonId);

INSERT INTO Passports 
VALUES (101, 'N34FG21B'),
       (102,'K65LO4R7'),
	   (103,'ZE657QP2')

INSERT INTO Persons 
VALUES (1, 'Roberto', 43300.00,102),                                
       (2,'Tom',56100.00,103),
	   (3,'Yana',60200.00,101)

----2

CREATE TABLE Manufacturers (
    ManufacturerID INT NOT NULL PRIMARY KEY,
    [Name] VARCHAR(40),
	EstablishedOn DATETIME
  );


CREATE TABLE Models (
    ModelID INT NOT NULL PRIMARY KEY,
    [Name] VARCHAR(40),
	ManufacturerID INT,
	CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID)
    REFERENCES Manufacturers(ManufacturerID)
);


INSERT INTO Manufacturers 
VALUES (1, 'BMW','07/03/1916'),
       (2,'Tesla','01/01/2003'),
	   (3,'Lada','01/05/1966')

INSERT INTO Models 
VALUES (101, 'X1', 1),                                
       (102,'i6',1),
	   (103,'Model S',2),
	   (104, 'Model X', 2),                                
       (105,'Model 3',2),
	   (106,'Nova',3)

----3
CREATE TABLE Students (
    StudentID INT NOT NULL PRIMARY KEY,
    [Name] VARCHAR(40),
	);


CREATE TABLE Exams (
    ExamID INT NOT NULL PRIMARY KEY,
    [Name] VARCHAR(40),
);

CREATE TABLE StudentsExams (
    StudentID INT NOT NULL,
    ExamID INT NOT NULL,
	CONSTRAINT PK_ExamsStudents
	PRIMARY KEY (StudentID, ExamID),
	CONSTRAINT FK_ExamsStudents_Students FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),
	CONSTRAINT FK_ExamsStudents_Exams FOREIGN KEY (ExamID)
    REFERENCES Exams(ExamID)
);


INSERT INTO Students 
VALUES (1, 'Mila'),
       (2,'Toni'),
	   (3,'Ron')

INSERT INTO Exams 
VALUES (101, 'SpringMVC'),
       (102,'Neo4j'),
	   (103,'Oracle 11g')

INSERT INTO StudentsExams 
VALUES (1,101),
       (1,102),
	   (2,101),
	   (3,103),
       (2,102),
	   (2,103)

---4
CREATE TABLE Teachers (
    TeacherID INT NOT NULL PRIMARY KEY,
    [Name] VARCHAR(40),
	ManagerID INT,
	CONSTRAINT FK_Teachers FOREIGN KEY (ManagerID)
    REFERENCES Teachers(TeacherID),
	);

INSERT INTO Teachers 
VALUES (101, 'John',NULL),
       (102, 'Maya',106),
	   (103, 'Silvia',106),
	   (104, 'Ted',105),
	   (105, 'Mark',101),
	   (106, 'Greta',101)

---5
CREATE TABLE Cities (
    CityID INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
	);

CREATE TABLE Customers (
    CustomerID INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
	Birthday DATE ,
	CityID INT,
	CONSTRAINT FK_CustomersCities FOREIGN KEY (CityID)
    REFERENCES Cities(CityID)
	);

CREATE TABLE Orders (
    OrderID INT NOT NULL PRIMARY KEY,
    CustomerID INT NOT NULL,
	CONSTRAINT FK_OrdersCustomers FOREIGN KEY (CustomerID)
    REFERENCES Customers(CustomerID)
	);

CREATE TABLE ItemTypes (
    ItemTypeID INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
	);

CREATE TABLE Items (
    ItemID INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL,
	CONSTRAINT FK_ItemsItemTypes
      FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes (ItemTypeID)
	);

CREATE TABLE OrderItems (
    OrderID INT NOT NULL,
    ItemID INT NOT NULL,
	CONSTRAINT PK_OrderID_ItemID PRIMARY KEY (OrderID, ItemID),
    CONSTRAINT FK_OrderItemsOrders
      FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
    CONSTRAINT FK_OrderItemsItems
      FOREIGN KEY (ItemID) REFERENCES Items (ItemID)
	);

----6
CREATE TABLE Majors (
    MajorID INT NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
	);

CREATE TABLE Students (
   StudentID INT NOT NULL PRIMARY KEY,
   StudentNumber INT NOT NULL,
   StudentName VARCHAR(50),
   MajorID INT NOT NULL
    CONSTRAINT FK_StudentsMajors
      FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
);

CREATE TABLE Payments (
   PaymentID INT NOT NULL PRIMARY KEY,
   PaymentDate DATETIME NOT NULL,
   PaymentAmount MONEY,
   StudentID INT NOT NULL,
   CONSTRAINT FK_PaymentsStudents
      FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

CREATE TABLE Subjects (
    SubjectID INT NOT NULL PRIMARY KEY,
    SubjectName VARCHAR(50) NOT NULL,
	);

CREATE TABLE Agenda (
    SubjectID INT NOT NULL,
    StudentID INT NOT NULL,
	CONSTRAINT PK_SubjectID_StudentID PRIMARY KEY (SubjectID, StudentID),
    CONSTRAINT FK_AgendaStudents
      FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
    CONSTRAINT FK_AgendaSubjects
      FOREIGN KEY (SubjectID) REFERENCES Subjects (SubjectID)
	);

----9

SELECT 
	MiD.MountainRange,PeakName,Elevation
FROM 
	(SELECT 
		Id,MountainRange
	FROM 
		Mountains
	WHERE
		MountainRange = 'Rila') AS MiD , Peaks
WHERE
	MountainId = MiD.Id
ORDER BY 
	Elevation DESC