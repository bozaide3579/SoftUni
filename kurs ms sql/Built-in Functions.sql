--01
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--02
 SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10) AND 
DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--04
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05
SELECT [Name]
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name] ASC

--06
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[mkbe]%'
ORDER BY [Name] ASC

--07
SELECT TownID, [Name]
FROM Towns
WHERE [Name] NOT LIKE '[rbd]%'
ORDER BY [Name] ASC

--08
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees 
WHERE DATEPART(YEAR, HireDate) > 2000

--09
SELECT FirstName, LastName
FROM Employees 
WHERE Len(LastName) = 5

--10
SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER
	(PARTITION BY Salary ORDER BY EmployeeID)
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11
WITH CTE_RankedEmployees AS
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER
		(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
)
SELECT * 
FROM CTE_RankedEmployees
WHERE [Rank] = 2
ORDER BY Salary DESC

--12
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13
SELECT PeakName, RiverName,
LOWER (CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName)-1), RiverName)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix ASC

--14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS Start
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

--16
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username 

--17
SELECT [Name], 
	[Part of the Day] = 
	CASE	
		WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END,
	[Duration] = 
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] <= 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END
FROM Games
ORDER BY [Name], [Duration], [Part of the Day] 

--18
CREATE TABLE Orders
(
	ID INT PRIMARY KEY IDENTITY,
	ProductName VARCHAR(60),
	OrderDate DATETIME2
)

INSERT INTO Orders VALUES ('Butter', GETDATE()),
						  ('Milk', GETDATE()),
						  ('Honey', GETDATE())

SELECT ProductName, OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM ORDERS

--19
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(32),
	Birthdate DATETIME2
)

INSERT INTO People (Name, Birthdate)
VALUES					  
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000')

SELECT 
	Name,
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People
