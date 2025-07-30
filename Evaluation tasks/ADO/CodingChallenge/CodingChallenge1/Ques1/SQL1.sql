CREATE TABLE Employee_Details (Empid INT IDENTITY(1,1) PRIMARY KEY,
EmpName VARCHAR(20), Salary INT, Gender VARCHAR(1))

CREATE PROCEDURE InsertEmployees
@name VARCHAR(20),
@salary INT,
@gender VARCHAR(1),
@generatedempid INT OUTPUT,
@calculatedsalary INT OUTPUT
AS BEGIN 
SET NOCOUNT ON 

SET @calculatedsalary = @salary - (0.10 * @salary)

 INSERT INTO Employee_Details (EmpName, Salary, Gender)
 VALUES (@name, @calculatedsalary, @gender);
 SET @generatedempId = SCOPE_IDENTITY();
END;
Drop procedure InsertEmployees
DECLARE @EmpId1 INT;
DECLARE @Sal1 INT;

EXEC InsertEmployees 
    @name = 'Alice',
    @salary = 60000, 
    @gender = 'F', 
    @generatedEmpId = @EmpId1 OUTPUT, 
    @calculatedsalary = @Sal1 OUTPUT;

DECLARE @EmpId2 INT;
DECLARE @Sal2 INT;

EXEC InsertEmployees 
    @name = 'Nisha',
    @salary = 80000, 
    @gender = 'F', 
    @generatedEmpId = @EmpId2 OUTPUT, 
    @calculatedsalary = @Sal2 OUTPUT;


Select * from Employee_Details