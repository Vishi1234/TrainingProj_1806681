-- Query 1 : T-SQL Program to find the factorial of a given number.
DECLARE @n INT = 5
DECLARE @i INT = 1
DECLARE @fact BIGINT = 1

WHILE @i <= @n
BEGIN 
    SET @fact = @fact * @i;
	SET @i = @i + 1;
END 

SELECT @fact AS Factorial_number

-- Query 2 : Stored procedure to generate multiplication table that accepts a number and generates up to a given number.
CREATE PROCEDURE sp_Multiplication
@num INT, @upto INT
AS 
BEGIN
  DECLARE @i INT = 1;
  PRINT 'Multiplication for' + ' ' +  CAST(@num as VARCHAR);
  WHILE @i <= @upto
  BEGIN 
     PRINT CAST(@num AS VARCHAR) + '*' + CAST(@i AS VARCHAR) + '=' + CAST(@num * @i AS VARCHAR);
	 SET @i = @i + 1;
  END
END;

sp_Multiplication 3, 8

CREATE TABLE Student (
Sid INT PRIMARY KEY,
Sname VARCHAR(20)
);

INSERT INTO Student VALUES 
(1, 'Jack'),
(2,' Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj')

CREATE TABLE Marks (
Mid INT PRIMARY KEY,
Sid INT,
score INT
);

INSERT INTO Marks VALUES 
(1,1,23),
(2,6,95),
(3,4,98),
(4,2,17),
(5,3,53),
(6,5,13)


-- Query 3 
CREATE FUNCTION fnPassFail(@ename VARCHAR(30), @score INT)
RETURNS VARCHAR(10)
AS BEGIN 
  DECLARE @result VARCHAR(10)
    IF (@score >= 50) 
	   SET @result = 'Pass'
	ELSE
	   SET @result = 'Fail'
	RETURN @result
END;

SELECT dbo.fnPassFail('Jaspreet', 53) AS result;