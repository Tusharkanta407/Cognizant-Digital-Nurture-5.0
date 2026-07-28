-- ==========================================
-- Module 03 - Advanced SQL: Exercise 4 (Task 5)
-- Task: Return Data from Stored Procedure
-- ==========================================

-- 1. Create Procedure with an OUTPUT parameter
CREATE OR ALTER PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT,
    @EmployeeCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- 2. Execution block verifying output retrieval
DECLARE @TotalCount INT;

EXEC sp_GetEmployeeCountByDepartment 
    @DepartmentID = 101, 
    @EmployeeCount = @TotalCount OUTPUT;

SELECT @TotalCount AS 'Total Employees in Department 101';