CREATE DATABASE TouristAgency

--1
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	BedCount INT NOT NULL
		CHECK(BedCount > 0 AND BedCount <= 10)
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
)

CREATE TABLE Tourists
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Bookings
(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL
		CHECK(AdultsCount >= 1 AND AdultsCount <= 10),
	ChildrenCount INT NOT NULL
		CHECK(ChildrenCount >= 0 AND ChildrenCount <= 9),
	TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
)

CREATE TABLE HotelsRooms
(
	HotelId INT NOT NULL,
	RoomId INT NOT NULL
	CONSTRAINT PK_HotelsRooms PRIMARY KEY (HotelId, RoomId),
	CONSTRAINT FK_HotelsRooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
	CONSTRAINT FK_HotelsRooms_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
)

--2
INSERT INTO Tourists
	VALUES('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
	('Adeline Agla�', '122-654-8726', 'adeline.aglae@example.com', 2),
	('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
	('Johan M�ller', '322-876-9826', 'j.muller@example.com', 7),
	('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings
	VALUES ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
	('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
	('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
	('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
	('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

--3
UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate <= '2023-12-31'

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

--4
BEGIN TRANSACTION
	DECLARE @ToutistsToDelete TABLE (Id INT)

	INSERT INTO @ToutistsToDelete(Id)
		SELECT Id
		FROM Tourists
		WHERE [Name] LIKE '%Smith%'

	DELETE FROM Bookings
	WHERE TouristId IN (SELECT Id FROM @ToutistsToDelete)

	DELETE FROM Tourists
	WHERE Id IN (SELECT Id FROM @ToutistsToDelete)
COMMIT

--5
SELECT 
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
	AdultsCount, ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
ORDER BY r.Price DESC, ArrivalDate

--6
SELECT h.Id, h.[Name]
FROM Hotels AS h
JOIN HotelsRooms AS hr On h.Id = hr.HotelId
JOIN Rooms AS r ON hr.RoomId = r.Id
JOIN Bookings AS b On h.Id = b.HotelId 
	AND r.Type = 'VIP Apartment'
	GROUP BY h.Id, h.[Name]
ORDER BY COUNT(*) DESC

--7
SELECT t.Id, t.[Name], t.PhoneNumber
FROM Tourists AS t
WHERE Id NOT IN (SELECT TouristId FROM Bookings)
ORDER BY [Name] ASC

--8
SELECT TOP(10) 
	h.[Name] AS HotelName, 
	d.[Name] AS DestinationName, 
	c.[Name] AS CountryName
FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Destinations AS d ON d.Id = h.DestinationId
JOIN Countries AS c ON c.Id = d.CountryId
WHERE 
	ArrivalDate < '2023-12-31' AND 
	h.Id % 2 != 0
ORDER BY c.[Name], ArrivalDate

--9
SELECT 
	h.[Name] AS HotelName,
	r.Price AS RoomPrice
FROM Tourists AS t
JOIN Bookings AS b ON b.TouristId = t.Id
JOIN Rooms AS r On r.Id = b.RoomId
JOIN Hotels AS h On h.Id = b.HotelId
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC

--10
SELECT 
	h.[Name] AS Hotel,
	SUM(Price * DATEDIFF(DAY, ArrivalDate, DepartureDate)) AS HotelRevenue
FROM Bookings AS b
JOIN Hotels AS h ON b.HotelId = h.Id
JOIN Rooms AS r ON b.RoomId = r.Id
GROUP BY h.[Name]
ORDER BY HotelRevenue DESC

--11
CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
RETURN
(
	SELECT 
		SUM(AdultsCount + ChildrenCount)
	FROM Bookings AS b
	JOIN Rooms AS r On r.Id = b.RoomId
	WHERE [Type] = @name
)
END

--12
CREATE PROC usp_SearchByCountry(@country VARCHAR(128))
AS
BEGIN
	SELECT 
		t.[Name], PhoneNumber, Email,
		COUNT(b.Id) AS CountOfBookings
	FROM Tourists AS t
	JOIN Bookings AS b On b.TouristId = t.Id
	JOIN Countries AS c On c.Id = t.CountryId
	WHERE c.Name = @country
	GROUP BY t.[Name], PhoneNumber, Email
	ORDER BY t.[Name], CountOfBookings DESC
END
