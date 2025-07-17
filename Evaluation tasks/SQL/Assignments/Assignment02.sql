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


-- QUERY 1
SELECT * FROM EMPP WHERE ename LIKE 'A%';

-- QUERY 2
SELECT * FROM EMPP WHERE mgr_id IS NULL;

-- QUERY 3 
SELECT ename, empno, sal FROM EMPP
WHERE sal BETWEEN 1200 AND 1400;

-- Query 4 
SELECT ename, Dname FROM EMPP
JOIN DEPTT ON EMPP.Deptno = DEPTT.Deptno
WHERE Dname = 'RESEARCH';

UPDATE EMPP
SET sal = sal * 1.10
WHERE Deptno IN (
  SELECT Deptno FROM DEPTT WHERE Dname = 'RESEARCH'
);

SELECT E.*
FROM EMPP E
JOIN DEPTT D ON E.Deptno = D.Deptno
WHERE D.Dname = 'RESEARCH';


--Query 5 
PRINT('The number of clerks that are employed in the company are as follows')
SELECT job, COUNT(empno) AS no_of_employees
FROM EMPP
WHERE job = 'CLERK'
GROUP BY job;

-- Query 6
SELECT JOB, AVG(sal) AS average_salary, COUNT(empno) as no_of_employees FROM EMPP
GROUP BY JOB;

--Query 7 
SELECT * FROM EMPP
WHERE sal IN (SELECT MAX(sal) FROM EMPP UNION SELECT MIN(sal) FROM EMPP);

--QUERY 8 
SELECT D.*
FROM DEPTT D
LEFT JOIN EMPP E ON D.Deptno = E.Deptno
WHERE E.empno IS NULL;

-- Query 9 
SELECT ename, sal, Deptno FROM EMPP
WHERE job = 'ANALYST' AND sal>1200 AND Deptno = 20;

-- Query 10
SELECT DEPTT.Deptno, Dname, SUM(sal) AS total_salary FROM DEPTT
JOIN EMPP ON DEPTT.Deptno = EMPP.Deptno
GROUP BY DEPTT.Deptno, DEPTT.Dname;

-- Query 11
SELECT sal, ename
FROM EMPP
WHERE ename IN ('MILLER', 'SMITH');

-- Query 12
SELECT ename from EMPP
WHERE ename LIKE 'A%' OR ename LIKE 'M%';

-- Query 13 
SELECT ename, (sal*12) AS yearly_salary FROM EMPP
WHERE ename = 'SMITH';

-- Query 14
SELECT ename, sal FROM EMPP
WHERE sal NOT BETWEEN 1500 AND 2850;

-- Query 15
SELECT mgr_id, COUNT(mgr_id) as no_of_employees_reporting FROM EMPP
GROUP BY mgr_id
