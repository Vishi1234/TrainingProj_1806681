-- Query 1 
SELECT DATENAME(WEEKDAY, '2003-05-04') AS Day_of_week

-- Query 2
SELECT DATEDIFF(YEAR, '2003-05-04', GETDATE()) AS My_Age

-- Query 3
UPDATE EMPP SET hire_date = '1980-07-23' WHERE empno = 7369
UPDATE EMPP SET hire_date = '1956-07-12' WHERE empno = 7698
UPDATE EMPP SET hire_date = '2017-07-23' WHERE empno = 7782
SELECT ename, hire_date, DATEDIFF(YEAR, hire_date, GETDATE()) AS EXPERIENCE FROM EMPP
WHERE DATEDIFF(YEAR, hire_date, GETDATE()) > 5  AND MONTH(hire_date) = MONTH(GETDATE())

-- Query 4
BEGIN TRANSACTION

INSERT INTO EMPP VALUES (1000, 'KRISH','SALESMAN', 5666, '1985-03-23', 500, null, 20),
(2000, 'YASH','CLERK', 5555, '1985-08-01', 1200, null, 10),
(3000, 'ANSH','ANALYST', 6766, '1985-10-13', 1800, null, 30)

UPDATE EMPP SET sal = (sal * 1.15) WHERE empno = 2000
SAVE TRANSACTION t1

DELETE FROM EMPP WHERE empno = 1000
  SAVE TRANSACTION t2

ROLLBACK TRAN t2
SELECT * FROM EMPP
COMMIT

-- Query 5
CREATE FUNCTION calculate_bonus (@sal INT, @deptno INT)
RETURNS DECIMAL(7,2)
AS
BEGIN
    DECLARE @bonus DECIMAL(7,2);
 
    IF @deptno = 10
        SET @bonus = @sal * 0.15;
    ELSE IF @deptno = 20
        SET @bonus = @sal * 0.20;
    ELSE
        SET @bonus = @sal * 0.05;
 
    RETURN @bonus;
END;
 
SELECT
    empno, 
    ename, 
    sal, 
    deptno,
    dbo.calculate_bonus(sal, deptno) AS bonus
FROM EMPP;

-- Query 6 : 
CREATE OR ALTER PROCEDURE update_IN_SALARY
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE EMPP
    SET sal = sal + 500
    WHERE Deptno IN (
        SELECT Deptno 
        FROM DEPTT 
        WHERE Dname = 'RESEARCH'
    )
    AND sal < 1500;
END;

 
EXEC update_IN_SALARY;

SELECT * FROM EMPP;
SELECT * FROM DEPTT;