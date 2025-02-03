CREATE DATABASE LibraryDb 
USE LibraryDb

--1
CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100) NULL,
	PhoneNumber NVARCHAR(20) NULL,
	PostAddress NVARCHAR(200) NULL,
	Website NVARCHAR(50) NULL
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL
)

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
)

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
)

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) NOT NULL UNIQUE,
	AuthorId INT NOT NULL FOREIGN KEY REFERENCES Authors(Id),
	GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id)
)

CREATE TABLE LibrariesBooks
(
	LibraryId INT NOT NULL FOREIGN KEY REFERENCES Libraries(Id),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Books(Id),
	PRIMARY KEY (LibraryId, BookId)
)

--2 
INSERT INTO Contacts
	VALUES(NULL, NULL, NULL, NULL),
		(NULL, NULL, NULL, NULL),
		('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
		('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO Authors
	VALUES('George Orwell', 21),
		('Aldous Huxley', 22),
		('Stephen King', 23),
		('Suzanne Collins', 24)

INSERT INTO Books
	VALUES ('1984', 1949, '9780451524935', 16, 2),
		('Animal Farm', 1945, '9780451526342', 16, 2),
		('Brave New World', 1932, '9780060850524', 17, 2),
		('The Doors of Perception', 1954, '9780060850531', 17, 2),
		('The Shining', 1977, '9780307743657', 18, 9),
		('It', 1986, '9781501142970', 18, 9),
		('The Hunger Games', 2008, '9780439023481', 19, 7),
		('Catching Fire', 2009, '9780439023498', 19, 7),
		('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO LibrariesBooks
	VALUES (1, 36),
		(1, 37),
		(2, 38),
		(2, 39),
		(3, 40),
		(3, 41),
		(4, 42)

--3
UPDATE Contacts
SET Website = CONCAT('www.', LOWER(REPLACE(a.Name, ' ', '')), '.com')
FROM Contacts AS c
JOIN Authors AS a ON a.ContactId = c.Id
WHERE c.Website IS NULL

--4
DECLARE @IdToDelete INT

SELECT @IdToDelete = Id
FROM Authors
WHERE Name = 'Alex Michaelides'

DELETE FROM LibrariesBooks
WHERE BookId IN
(
	SELECT Id 
	FROM Books 
	Where AuthorId = @IdToDelete
)

DELETE FROM Books
WHERE AuthorId = @IdToDelete

DELETE FROM Books
WHERE AuthorId = @IdToDelete

DELETE FROM Authors
WHERE Id = @IdToDelete


--5
SELECT Title, ISBN, YearPublished
FROM Books
ORDER BY YearPublished DESC, Title

--6
SELECT b.Id, Title, ISBN, g.[Name]
FROM Books AS b
JOIN Genres AS g ON g.Id = b.GenreId
WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY g.[Name], b.Title

--7
SELECT l.[Name], c.Email
FROM Libraries AS l
JOIN Contacts AS c ON c.Id = l.ContactId
WHERE l.Id NOT IN
(
	SELECT DISTINCT lb.LibraryId
	FROM LibrariesBooks lb
	JOIN Books AS b ON b.Id = lb.BookId
	JOIN Genres AS g ON g.Id = b.GenreId
	WHERE g.[Name] = 'Mystery'
)
ORDER BY l.[Name]


--8
SELECT TOP (3) b.Title, b.YearPublished, g.[Name]
FROM Books AS b
JOIN Genres AS g On g.Id = b.GenreId
WHERE b.YearPublished > 2000 AND
	  b.Title LIKE '%a%' 
	  OR
	  b.YearPublished < 1950 AND
	  g.[Name] LIKE '%Fantasy%'
ORDER BY b.Title ASC, b.YearPublished DESC

--9
SELECT a.[Name], c.Email, c.PostAddress
FROM Authors AS a
JOIN Contacts AS c ON c.Id = a.ContactId
WHERE c.PostAddress LIKE '%UK'
ORDER BY a.Name ASC

--10
SELECT a.[Name], b.Title, l.[Name], c.PostAddress
FROM Books AS b
JOIN Authors a ON a.Id = b.AuthorId
JOIN Genres g ON g.Id = b.GenreId
JOIN LibrariesBooks lb ON lb.BookId = b.Id
JOIN Libraries l ON l.Id = lb.LibraryId
JOIN Contacts c ON c.Id = l.ContactId
WHERE g.[Name] = 'Fiction' AND
	  c.PostAddress LIKE '%Denver%'
ORDER BY b.Title 

--11
 CREATE FUNCTION udf_AuthorsWithBooks(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
RETURN 
(
	SELECT COUNT(*)
	FROM Authors a
	JOIN Books b ON a.Id = b.AuthorId
	JOIN LibrariesBooks lb ON b.Id = lb.BookId
	WHERE a.Name = @name
)
END

--12
CREATE PROC usp_SearchByGenre(@genreName VARCHAR(128))
AS
BEGIN
	SELECT b.Title, b.YearPublished, b.ISBN, a.[Name], g.[Name]
	FROM Books b
	JOIN Authors a ON a.Id = b.AuthorId
	JOIN Genres g ON g.Id = b.GenreId
	WHERE g.[Name] = @genreName
	ORDER BY b.Title
END

