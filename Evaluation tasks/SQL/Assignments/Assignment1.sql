
-- TABLE 1 : CLIENTS
CREATE TABLE Clients (
Client_ID INT PRIMARY KEY,
Cname VARCHAR(40) NOT NULL,
Address VARCHAR (30),
Email VARCHAR(30) UNIQUE,
Phone BIGINT,
Business VARCHAR(20) NOT NULL);

INSERT INTO Clients VALUES 
(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant'),
(1003, 'MoneySaver Distributers', 'Kolkata','save@moneysaver.com', 7799886655, 'Reseller'),
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Profession');

-- TABLE 2 : DEPARTMENTS
CREATE TABLE Departments (
Deptno INT PRIMARY KEY,
Dname VARCHAR(15) NOT NULL,
Loc VARCHAR(20));

INSERT INTO Departments VALUES 
(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai');


-- TABLE 3 : EMPLOYEES
CREATE TABLE Employees (
Empno INT PRIMARY KEY,
Ename VARCHAR(20) NOT NULL,
Job VARCHAR(15),
Salary INT CONSTRAINT Salcheck CHECK(Salary > 0), 
Deptno INT FOREIGN KEY(Deptno) REFERENCES Departments(Deptno)
);

INSERT INTO Employees VALUES 
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10);



-- TABLE 4 : PROJECTS
CREATE TABLE Projects (
project_id INT PRIMARY KEY,
Descr VARCHAR(30) NOT NULL,
Startt_Date DATE,
Planned_End_Date DATE,
Actual_End_Date DATE,
Budget INT CONSTRAINT Budcheck CHECK(Budget>0),
Client_ID INT FOREIGN KEY(Client_ID) REFERENCES Clients(Client_ID)
);

INSERT INTO Projects VALUES 
(401,' Inventory', '01-Apr-11', '01-Oct-11', '31-Oct-11' ,150000, 1001),
(402, 'Accounting', '01-Aug-11' ,'01-Jan-12',null, 500000, 1002),
(403, 'Payroll', '01-Oct-11', '31-Dec-11',null, 75000, 1003),
(404, 'Contact Mgmt', '01-Nov-11', '31-Dec-11', null, 50000, 1004);

-- TABLE 5 : EMPPROJECTTASKS
CREATE TABLE EmpProjectTasks(
 project_id INT,
    empno INT,
    start_date DATE,
    end_date DATE,
    task VARCHAR(25) NOT NULL,
    status VARCHAR(15) NOT NULL,
    PRIMARY KEY (project_id, empno),
    FOREIGN KEY (project_id) REFERENCES Projects(project_id),
    FOREIGN KEY (empno) REFERENCES Employees(empno)
);
 
INSERT INTO empprojecttasks VALUES
(401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed'),
(401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed'),
(401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed'),
(401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed'),
(401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed'),
(401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed'),
(401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed'),
(401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed'),
(401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed'),
(402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed'),
(402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed'),
(402, 7004, '2011-10-01', null, 'Coding', 'In Progress');


