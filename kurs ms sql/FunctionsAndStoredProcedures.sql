--1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

--2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @salary
END

EXEC usp_GetEmployeesSalaryAboveNumber 50000

--3
CREATE PROC usp_GetTownsStartingWith @inputString VARCHAR(MAX)
AS
BEGIN
	SELECT [Name] AS Town
	FROM Towns
	WHERE [Name] Like CONCAT(@inputString, '%')
END

--4
CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
BEGIN	
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a On a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)

	IF(@salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF (@salary BETWEEN 30000 AND 50000)
		SET @salaryLevel = 'Average'
	ELSE IF (@salary > 50000)
		SET @salaryLevel = 'High'

	RETURN @salaryLevel
END

SELECT FirstName, Salary,
	dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

--6
CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

--07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @wordLength int = LEN(@word)
	DECLARE @iterator INT = 1

	WHILE(@iterator <= @wordLength)
		BEGIN
			IF(CHARINDEX(SUBSTRING(@word, @iterator, 1), @setOfLetters) = 0)
				RETURN 0
			SET @iterator += 1
		END
	RETURN 1
END

--8
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DECLARE @deletedEmployees TABLE(Id INT)
	INSERT INTO @deletedEmployees
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN
	(
		SELECT Id FROM @deletedEmployees
	)

	DELETE FROM EmployeesProjects
	WHERE EmployeeID In 
	(
		SELECT Id FROM @deletedEmployees
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE EmployeeID IN
	(
		SELECT Id FROM @deletedEmployees
	)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

--9
CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT_WS(' ', FirstName, LastName) AS [Full Name]
	FROM AccountHolders
END

--10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@num money)
AS
BEGIN
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY FirstName, LastName
	HAVING SUM(a.Balance) > @num
	ORDER BY FirstName, LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 500000

--11
CREATE FUNCTION ufn_CalculateFutureValue (@sum Decimal(10,4), @yearlyInterestRate FLOAT, @numOfYears INT)
RETURNS DECIMAL(10,4)
AS
BEGIN
	RETURN @sum * (POWER((1 + @yearlyInterestRate), @numOfYears))
END

--12
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accID INT, @interstRate FLOAT)
AS
	DECLARE @term INT = 5
	SELECT
		a.Id AS [Account Id],
		FirstName, 
		LastName, 
		Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(Balance, @interstRate, @term) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accID

--13
CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS
RETURN(
SELECT SUM(Cash) AS SumCash
FROM 
	(SELECT
		g.Id,
		g.[Name],
		ug.Cash,
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowRank
	FROM Games AS g
	JOIN UsersGames AS ug On ug.GameId = g.Id
	WHERE g.[Name] = @gameName) AS NestedQuery

	WHERE RowRank % 2 = 1)
