--1
CREATE DATABASE RailwaysDb

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Trains
(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id),
	ArrivalTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE TrainsRailwayStations
(
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
	RailwayStationId INT NOT NULL FOREIGN KEY REFERENCES RailwayStations(Id),
	PRIMARY KEY (TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords
(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATE NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id)
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

--2
INSERT INTO Trains
	VALUES('07:00', '19:00', 1, 3),
		('08:30', '20:30', 5, 6),
		('09:00', '21:00', 4, 8),
		('06:45', '03:55', 27, 7),
		('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations
	VALUES(36, 1),
		(36, 4),
		(36, 31),
		(36, 57),
		(36, 7),
		(37, 13),
		(37, 54),
		(37, 60),
		(37, 16),
		(38, 10),
		(38, 50),
		(38, 52),
		(38, 22),
		(39, 68),
		(39, 3),
		(39, 31),
		(39, 19),
		(40, 41),
		(40, 7),
		(40, 52),
		(40, 13)

INSERT INTO Tickets
	VALUES(90.00, '2023-12-01', '2023-12-01', 36, 1),
		(115.00, '2023-08-02', '2023-08-02', 37, 2),
		(160.00, '2023-08-03', '2023-08-03', 38, 3),
		(255.00, '2023-09-01', '2023-09-02', 39, 21),
		(95.00, '2023-09-02', '2023-09-03', 40, 22)

--3
UPDATE Tickets
SET DateOfDeparture = DATEADD(WEEK, 1, DateOfDeparture),
	DateOfArrival = DATEADD(WEEK, 1, DateOfArrival)
WHERE DATEPART (MONTH, DateOfDeparture) > 10

--4
DECLARE @TrainId INT
SELECT @TrainId = Id 
FROM Trains 
WHERE DepartureTownId = (SELECT Id FROM Towns WHERE [Name] = 'Berlin')

DELETE FROM Tickets WHERE TrainId = @TrainId
DELETE FROM MaintenanceRecords WHERE TrainId = @TrainId
DELETE FROM TrainsRailwayStations WHERE TrainId = @TrainId

DELETE FROM Trains WHERE Id = @TrainId

--5
SELECT DateOfDeparture, Price AS TicketPrice
FROM Tickets AS t
ORDER BY Price ASC, DateOfDeparture DESC

--6
SELECT p.[Name], Price AS TicketPrice, DateOfDeparture, TrainId
FROM Tickets AS t
JOIN Passengers AS p ON p.Id = t.PassengerId
ORDER BY Price DESC, p.[Name] 

--7
SELECT t.[Name], rs.[Name]
FROM RailwayStations AS rs
JOIN Towns AS t ON t.Id = rs.TownId
WHERE rs.Id NOT IN 
(
	SELECT RailwayStationId
	FROM TrainsRailwayStations
)
ORDER BY t.[Name] ASC, rs.[Name] ASC

--8
SELECT TOP(3) 
	tr.Id,
	HourOfDeparture,
	ti.Price AS TicketPrice,
	tow.[Name] AS Destination
FROM TRAINS AS tr
JOIN Towns AS tow ON tow.Id = tr.ArrivalTownId
JOIN Tickets AS ti ON ti.TrainId = tr.Id
WHERE 
	CAST(tr.HourOfDeparture AS TIME) BETWEEN '08:00' AND '08:59' AND
	ti.Price > 50.00
ORDER BY
	ti.Price ASC

--9
SELECT 
	tow.[Name] AS TownName, 
	COUNT(p.Id) AS PassengersCount
FROM Passengers AS p
JOIN Tickets AS ti ON ti.PassengerId = p.Id
JOIN Trains AS tr ON tr.Id = ti.TrainId
JOIN Towns AS tow ON tow.Id = tr.ArrivalTownId
WHERE ti.Price > 76.99
GROUP BY tow.[Name]
ORDER BY tow.[Name]

--10
SELECT tr.Id, tow.[Name], mr.Details
FROM Trains AS tr
JOIN MaintenanceRecords AS mr ON mr.TrainId = tr.Id
JOIN Towns AS tow ON tow.Id = tr.DepartureTownId
WHERE mr.Details LIKE '%inspection%'
ORDER BY tr.Id

--11
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(50))
RETURNS INT 
AS
BEGIN
RETURN
(
	SELECT
		COUNT(*)
	FROM Trains AS tr
	JOIN Towns AS dep ON dep.Id = tr.DepartureTownId
	JOIN Towns AS arr On arr.Id = tr.ArrivalTownId
	WHERE dep.[Name] = @name OR arr.[Name] = @name
)
END

--12
CREATE PROC usp_SearchByTown(@townName VARCHAR(50))
AS
BEGIN 
	SELECT p.[Name], ti.DateOfDeparture, tr.HourOfDeparture
	FROM Passengers AS p
	JOIN Tickets AS ti ON ti.PassengerId = p.Id
	JOIN Trains AS tr ON tr.Id = ti.TrainId
	JOIN Towns AS tow On tow.Id = tr.ArrivalTownId
	WHERE tow.[Name] = @townName
	ORDER BY ti.DateOfDeparture DESC, p.[Name] ASC
END



