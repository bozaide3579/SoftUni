Create database Minions

Create TABLE Minions
(
Id Int Primary Key,
[Name] Varchar(50),
Age Int
)
Create TABLE Towns
(
Id Int Primary Key,
[Name] Varchar(50)
)

Alter Table Minions
Add TownId Int

Alter Table Minions
Add Foreign Key (TownId) References Towns(Id)

Insert Into Towns
Values (1, 'Sofia'),
       (2, 'Plovdiv'),
	   (3, 'Varna')

Insert Into Minions (Id, [Name], Age, TownId)
Values(1, 'Kevin', 22, 1),
      (2, 'Bob', 15, 3),
	  (3, 'Steward', Null, 2)


Truncate Table Minions
Select * From Minions

Drop Table Minions
Drop Table Towns

Create Table People
(
    Id Int Primary Key Identity(1, 1),
	[Name] Nvarchar(200) Not Null,
	Picture Varbinary(Max),
	Height Decimal(3,2),
	[Weight] Decimal(5,2),
	Gender Char(1) Not Null,
	    Check(Gender in ('m', 'f')),
	Birthdate Datetime2 Not Null,
	Biography Varchar(Max)
) 

Insert Into People ([Name], Gender, Birthdate)
				Values('Pesho', 'f', '1998-05-05'),
					  ('Radka', 'f', '1988-05-05'),
					  ('Hari', 'm', '2000-05-05'),
					  ('Peshoo', 'm', '1898-05-05'),
					  ('Dragan', 'm', '1798-05-05')



Create Table Users
(
    Id Bigint Primary Key Identity,
	Username Varchar(30) Not Null,
	[Password] Varchar(26) Not Null,
	ProfilePicture Varbinary(Max),
	LastLoginTime Datetime2,
	IsDeleted Bit
) 

Insert Into Users (Username, [Password])
				Values ('pesho123', '122334'),
				('ivan', '98893267'),
				('maria', '32432543'),
				('goshgo', '3463476'),
				('rad', '546457')

Alter Table Users
Drop Constraint PK__Users__3214EC07E7267BD1

Alter Table Users
Add Constraint PK_UsersTable Primary Key(Id, Username) 

Alter Table Users
Add Constraint CHK_PasswordIsAtleastFiveSymbols
	Check(Len(Password) >= 5)

Create Database SoftUni
Use SoftUni

Create Table Towns
(
	Id Int Primary Key Identity,
	[Name] Varchar(60) 
)

Create Table Adresses
(
	Id Int Primary Key Identity,
	AdressText Varchar(Max),
	TownId Int Foreign Key References Towns(Id)
)

Create Table Departments
(
	Id Int Primary Key Identity,
	[Name] Varchar(60) 
)

Create Table Employees
(
	Id Int Primary Key Identity,
	FirstName Varchar(60) not null,
	MiddleName Varchar(60),
	LastName Varchar(60) not null,
	JobTitle Varchar(60) not null,
	DepartmentId Int Foreign Key References Departments(Id),
	HireDate Datetime2 not null,
	Salary Decimal(10,2) not null,
	AddressId Int Foreign Key References Adresses(Id)
)

Insert Into Departments
			Values ('Software Development'),
			('Engineering'),
			('Quality Assurance'),
			('Sales'),
			('Marketing')

Insert Into Towns
			Values ('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')

Insert Into Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
			Values ('Ivan', 'Ivanov', 'Ivanov', 'NET Development', 1, '2013-02-01', 3500),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 2, '2004-02-01', 4000),
			('Maria', 'Petrova', 'Ivanova', 'Intern', 3, '2016-12-10', 5000),
		    ('Georgi', 'Terziev', 'Petrov', 'CEO', 4, '2000-02-01', 6000),
			('Petar', 'Pan', 'Pan', 'Senior Engineer', 5, '2004-02-01', 10000)

Update Employees
Set Salary = Salary * 1.1

Select Salary From Employees