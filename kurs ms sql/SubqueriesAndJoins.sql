--1
SELECT TOP (5) EmployeeID, JobTitle, e.AddressID, AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY AddressID


--2
SELECT TOP(50) FirstName, LastName, [Name], AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName ASC, LastName

--3
SELECT EmployeeID, FirstName, LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID ASC

--4
SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID ASC

--5
SELECT TOP(3) EmployeeID, FirstName
FROM Employees 
WHERE EmployeeID NOT IN (SELECT DISTINCT EmployeeID FROM EmployeesProjects)
ORDER BY EmployeeID ASC

--6
SELECT FirstName, LastName, HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d On d.DepartmentID = e.DepartmentID
WHERE HireDate > '1999-01-01' AND 
	  d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--7
SELECT TOP(5) e.EmployeeID, FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND 
	  p.EndDate IS NULL
ORDER BY EmployeeID ASC

--8
SELECT e.EmployeeID, FirstName, [Project Name] = 
CASE
	WHEN DATEPART(YEAR, StartDate) > 2004 THEN NULL
	ELSE [Name]
END
FROM EmployeesProjects AS ep
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
JOIN Employees AS e on e.EmployeeID = ep.EmployeeID
WHERE e.EmployeeID = 24

--9
SELECT emp.EmployeeID, emp.FirstName, mgr.EmployeeID, mgr.FirstName
FROM Employees AS emp
LEFT JOIN Employees AS mgr ON emp.ManagerID = mgr.EmployeeID
WHERE emp.ManagerID IN (3, 7)
ORDER BY emp.EmployeeID ASC

--10
SELECT TOP(50)
	   emp.EmployeeID,
	   CONCAT_WS(' ', emp.FirstName, emp.LastName) AS EmployeeName,
	   CONCAT_WS(' ', mgr.FirstName, mgr.LastName) AS ManagerName,
	   d.[Name] AS DepartmentName
FROM Employees AS emp
JOIN Employees AS mgr On emp.ManagerID = mgr.EmployeeID
JOIN Departments AS d ON d.DepartmentID = emp.DepartmentID
ORDER BY emp.EmployeeID

--11
SELECT TOP 1 AVG(Salary) MinAvarageSalary
FROM Employees 
GROUP BY DepartmentID
ORDER BY MinAvarageSalary

--18
WITH PeaksRankedByElevation AS
(
	SELECT 
		c.CountryName,
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		DENSE_RANK() OVER
			(PARTITION BY c.CountryName ORDER BY Elevation DESC) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries  AS mc ON C.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
)

SELECT TOP(5)
	CountryName AS Country,
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') AS [Mountain]
FROM PeaksRankedByElevation
WHERE PeakRank = 1
ORDER BY CountryName, [Highest Peak Name]

--16
SELECT COUNT(*)
FROM Countries
WHERE CountryCode NOT IN (SELECT DISTINCT CountryCode FROM MountainsCountries)

--17
SELECT TOP (5) 
	CountryName, 
	MAX(p.Elevation) AS HighestPeakElevation, 
	MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY 
	CountryName
ORDER BY 
	HighestPeakElevation DESC, 
	LongestRiverLength DESC, 
	CountryName 

--12
SELECT 
	c.CountryCode, 
	m.MountainRange, 
	p.PeakName, 
	p.Elevation
FROM 
	Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE 
	c.CountryCode = 'BG' AND
	p.Elevation > 2835
ORDER BY 
	p.Elevation DESC

--13
SELECT c.CountryCode, COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode

--14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r On r.Id = cr.RiverId
WHERE ContinentCode = 'AF'
ORDER BY c.CountryName

--15
WITH CurrencyUsageSummary AS 
(
    SELECT
        ContinentCode,
        CurrencyCode,
        COUNT(*) AS CurrencyUsage
    FROM
        Countries
    GROUP BY
        ContinentCode, CurrencyCode
),
FilteredCurrencies AS (
    SELECT
        ContinentCode,
        CurrencyCode,
        CurrencyUsage
    FROM
        CurrencyUsageSummary
    WHERE
        CurrencyUsage > 1
),
MostUsedCurrencies AS (
    SELECT
        ContinentCode,
        CurrencyCode,
        CurrencyUsage,
        RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS Rank
    FROM
        FilteredCurrencies
)
SELECT
    ContinentCode,
    CurrencyCode,
    CurrencyUsage
FROM
    MostUsedCurrencies
WHERE
    Rank = 1
ORDER BY
    ContinentCode;
