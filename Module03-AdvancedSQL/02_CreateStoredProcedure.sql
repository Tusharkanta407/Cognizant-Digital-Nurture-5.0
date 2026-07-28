-- ==========================================
-- Module 03 - Advanced SQL: Exercise 4 (Task 1)
-- Task: Create Stored Procedures
-- ==========================================

-- 1. Setup Dummy Base Table
IF OBJECT_ID('Employees') IS NOT NULL DROP TABLE Employees;

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE
);

INSERT INTO Employees VALUES ('John', 'Doe', 101, 75000.00, '2024-01-15');
GO

-- 2. Procedure to retrieve employee details by DepartmentID
CREATE OR ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- 3. Procedure to insert a new employee record
CREATE OR ALTER PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

-- 4. Test execution
EXEC sp_InsertEmployee 'Jane', 'Smith', 101, 82000.00, '2025-03-10';
EXEC sp_GetEmployeesByDepartment @DepartmentID = 101;