CREATE TABLE EMPP (
empno INT PRIMARY KEY,
ename VARCHAR(20),
job VARCHAR(20),
mgr_id INT,
hire_date DATE,
sal INT,
comm INT,
Deptno INT
);

INSERT INTO EMPP VALUES 
(7369, 'SMITH','CLERK',7902, '17-DEC-80', 800,NULL, 20),
(7499, 'ALLEN'  , 'SALESMAN', 7698 , '20-FEB-81', 1600,     300 ,   30),
(7521,'WARD', 'SALESMAN',7698    ,	'22-FEB-81'  ,	 1250   ,  500    ,30),
(7566  ,  'JONES','MANAGER ', 7839 , 	'02-APR-81',   	 2975, NULL, 20),
(7654,    'MARTIN', 'SALESMAN', 7698   	,' 28-SEP-81', 1250 ,   1400,    30),
(7698,	'BLAKE','MANAGER', 7839 , '01-MAY-81', 2850 , NULL, 30),
(7782, 	'CLARK', 'MANAGER', 7839  , '09-JUN-81',   	 2450, NULL,  10),
(7788,	'SCOTT', 'ANALYST',  7566  ,' 19-APR-87', 3000, NULL, 20),
(7839, 'KING' , 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698  , '08-SEP-81', 1500,  0, 30),
(7876, 'ADAMS', ' CLERK ' , 7788  , '23-MAY-87',       1100 , NULL, 20),
(7900, 'JAMES',    'CLERK' , 7698  , '03-DEC-81',  	 950, NULL, 30),
(7902, 'FORD',  'ANALYST' , 7566 , '03-DEC-81'  ,  	 3000  , NULL,  20),
(7934, 'MILLER', 'CLERK' , 7782 , '23-JAN-82',	 1300 , NULL,  10);

CREATE TABLE DEPTT (
Deptno INT PRIMARY KEY,
Dname VARCHAR(20),
Loc VARCHAR(20)
);

INSERT INTO DEPTT VALUES 
(10, 'ACCOUNTING', 'NEW YORK'), 
(20,  'RESEARCH',  'DALLAS'), 
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

-- Query 1 : List of Managers
SELECT empno, ename, job FROM EMPP
WHERE job = 'MANAGER';

-- Query 2 : Names and salaries of all employees earning more than 1000 per month.
SELECT ename, sal FROM EMPP
WHERE sal > 1000;

-- Query 3 : Names and salaries of all employees except JAMES.
SELECT ename, sal FROM EMPP
WHERE ename <> 'JAMES';

-- Query 4 : Details of employees whose names begin with ‘S’
SELECT * FROM EMPP
WHERE ename like 'S%';

-- Query 5 : Names of all employees that have ‘A’ anywhere in their name
SELECT  empno, ename FROM EMPP
WHERE ename like '%A%';

-- Query 6 : Names of all employees that have ‘L’ as their third character in their name. 
SELECT empno, ename FROM EMPP
WHERE ename like '__L%';

-- Query 7 : Daily salary of JONES
SELECT ename, (sal/30) as Daily_salary FROM EMPP
GROUP BY ename, sal
HAVING ename = 'JONES';

-- Query 8 : Total monthly salary of all employees
SELECT ename, sal AS Monthly_salary FROM EMPP

-- Query 9 : The average annual salary
SELECT avg(sal * 30) as Average_annual_salary FROM EMPP

-- Query 10 : name, job, salary, department number of all employees except SALESMAN from department number 30.
SELECT ename, job, sal, deptno FROM EMPP
GROUP BY ename, job, deptno, sal
HAVING job <> 'SALESMAN' and deptno <> 30;

-- Query 11 : Unique departments of the EMP table
SELECT DISTINCT d.Dname, d.Deptno, d.loc
FROM EMPP e
JOIN DEPTT d ON e.deptno = d.Deptno

-- Query 12 :  Name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
SELECT ename as Employee, sal AS Monthly_Salary, Deptno FROM EMPP
GROUP BY ename, sal, deptno
HAVING sal > 1500 AND deptno = 10 or deptno = 30;

-- Query 13 : name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
SELECT ename, job, sal FROM EMPP
WHERE job IN ('MANAGER', 'ANALAYST') AND sal NOT IN (1000, 3000, 5000)

-- Query 14 : Name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%.
SELECT ename, sal, comm FROM EMPP
GROUP BY ename, sal, comm
HAVING comm > (sal * 1.10)

-- Query 15 : Name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
SELECT ename, deptno, mgr_id FROM EMPP
WHERE ename LIKE '%L%L%' AND deptno = 30 OR mgr_id = 7782

-- Query 16 : names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees
SELECT ename, count(empno) AS Total_employees, hire_date
FROM EMPP
GROUP BY ename, hire_date
HAVING DATEDIFF(YEAR, hire_date, GETDATE()) > 30 AND DATEDIFF(YEAR, hire_date, GETDATE())  < 40

-- Query 17 : Names of departments in ascending order and their employees in descending order.
SELECT Dname, ename From DEPTT
JOIN EMPP ON DEPTT.deptno = EMPP.deptno
GROUP BY Dname, ename
ORDER BY Dname asc, ename desc

-- QUERY 18 : Experience of MILLER.
SELECT ename, hire_date, DATEDIFF(YEAR, hire_date, GETDATE()) AS EXPERIENCE FROM EMPP
WHERE ename = 'MILLER'

  