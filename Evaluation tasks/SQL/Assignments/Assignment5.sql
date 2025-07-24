-- Query 1 : 
CREATE PROCEDURE payslip_generation
    @empno INT
AS
BEGIN
    DECLARE 
        @ename NVARCHAR(100),
        @salary DECIMAL(10,2),
        @hra DECIMAL(10,2),
        @da DECIMAL(10,2),
        @pf DECIMAL(10,2),
        @it DECIMAL(10,2),
        @deductions DECIMAL(10,2),
        @gross DECIMAL(10,2),
        @net DECIMAL(10,2);
    SELECT @ename = ename, @salary = sal
    FROM EMPP
    WHERE empno = @empno;

    IF @ename IS NULL
    BEGIN
        PRINT 'Employee not found.';
        RETURN;
    END
    SET @hra = @salary * 0.10;
    SET @da = @salary * 0.20;
    SET @pf = @salary * 0.08;
    SET @it = @salary * 0.05;

    SET @deductions = @pf + @it;
    SET @gross = @salary + @hra + @da;
    SET @net = @gross - @deductions;
    PRINT 'Employee No : ' + CAST(@empno AS VARCHAR);
    PRINT 'Employee Name : ' + @ename;
    PRINT 'HRA (10%) : Rs ' + CAST(@hra AS VARCHAR);
    PRINT 'DA  (20%) : Rs ' + CAST(@da AS VARCHAR);
    PRINT 'Gross Salary : Rs ' + CAST(@gross AS VARCHAR);
    PRINT 'PF  (8%) : Rs ' + CAST(@pf AS VARCHAR);
    PRINT 'IT  (5%) : Rs ' + CAST(@it AS VARCHAR);
    PRINT 'Deductions : Rs ' + CAST(@deductions AS VARCHAR);
    PRINT 'Net Salary : Rs ' + CAST(@net AS VARCHAR);
END;

EXEC payslip_generation @empno = 2000;

-- Query 2 : 
CREATE TABLE HOLIDAYS (
    holiday_date DATE PRIMARY KEY,
    holiday_name NVARCHAR(100)
);

INSERT INTO HOLIDAYS VALUES ('2025-08-15', 'Independence Day');
INSERT INTO HOLIDAYS VALUES ('2025-11-02', 'Diwali');
INSERT INTO HOLIDAYS VALUES ('2025-07-24', 'Christmas');
INSERT INTO HOLIDAYS VALUES ('2026-01-26', 'Republic Day');
DROP TABLE HOLIDAYS
CREATE TRIGGER data_manipulation
ON EMPP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @holiday_name NVARCHAR(100);

    SELECT @holiday_name = holiday_name
    FROM HOLIDAYS
    WHERE holiday_date = CAST(GETDATE() AS DATE);

    IF @holiday_name IS NOT NULL
    BEGIN
        RAISERROR ('Due to %s you cannot manipulate data.', 16, 1, @holiday_name);
        ROLLBACK TRANSACTION;
    END
END;
