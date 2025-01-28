--1
CREATE OR ALTER TRIGGER tr_LogAccountChange
ON Accounts
FOR UPDATE
AS
	INSERT INTO Logs (AccountId, NewSum, OldSum)
	SELECT i.Id, i.Balance, d.Balance FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance <> d.Balance
GO


--2
CREATE TABLE dbo.NotificationEmails
(
Id INT IDENTITY NOT NULL, 
Recipient INT NOT NULL, 
[Subject] NVARCHAR(200) NOT NULL, 
Body NVARCHAR(1000) NOT NULL
)

CREATE OR ALTER TRIGGER tr_EmailNotification
ON Logs
FOR INSERT
AS
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	SELECT 
		i.AccountId,
		CONCAT_WS(' ', 'Balance change for account:', i.AccountId),
		CONCAT_WS (' ', 'On', GETDATE(), 'your balance was changed from', i.OldSum, 'to', i.NewSum)
	FROM inserted AS i
GO

--3
CREATE OR ALTER PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	IF @MoneyAmount > 0
	BEGIN
		UPDATE Accounts SET Balance = Balance + @MoneyAmount WHERE Id = @AccountId
	END	
END