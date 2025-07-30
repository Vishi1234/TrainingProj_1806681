CREATE TABLE Employee ( empid INT PRIMARY KEY, empname VARCHAR(20), salary INT)
drop table Employee
CREATE PROCEDURE EmployeesOp
@empid INT,
@name VARCHAR(20),
@salary INT,
@updatedsal INT OUTPUT
AS BEGIN
SET NOCOUNT ON 

SET @updatedsal = @salary + 100;

INSERT INTO Employee ( empid, empname, salary)
VALUES (@empid, @name, @salary)
END
drop procedure EmployeesOp
DECLARE @updatedsalary INT

EXEC EmployeesOp
   @empid = 101,
   @name = 'Deepak',
   @salary = 12345,
   @updatedsal = @updatedsalary OUTPUT

   select * from Employee