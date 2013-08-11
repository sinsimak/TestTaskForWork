USE MASTER
GO
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'Bank')
DROP DATABASE Bank

CREATE DATABASE Bank	
GO

USE Bank
CREATE TABLE Customers
(
	CustomerId int IDENTITY(1,1) NOT NULL,
	ContractNumber int NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	MiddleName nvarchar(50) NOT NULL, 
	LastName nvarchar(50) NOT NULL,
	
	
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerId)
)
GO


CREATE TABLE Accounts
(
	AccountId int IDENTITY(1,1) NOT NULL,
	AccountNumber nvarchar(20) NOT NULL,
	Balance money NOT NULL,
	CustomerId int NOT NULL,
	
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
	CONSTRAINT FK_Accounts_Customers FOREIGN KEY (CustomerId)
		REFERENCES Customers (CustomerId)	
)
GO

CREATE TABLE PaymentType
(
	PaymentTypeId int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	
	CONSTRAINT PK_PaymentType PRIMARY KEY(PaymentTypeId)
)
GO

CREATE TABLE Payments
(
	PaymentId int IDENTITY(1,1) NOT NULL,
	[Sum] money NOT NULL,
	PaymentDate datetime NOT NULL,
	AccountId int NOT NULL,
	PaymentTypeId int NOT NULL,
	Total money NOT NULL,
	
	CONSTRAINT PK_Payments_PaymentId PRIMARY KEY(PaymentId),

	CONSTRAINT FK_Payments_Accounts FOREIGN KEY (AccountId)
		REFERENCES Accounts (AccountId),
	CONSTRAINT FK_Payments_PaymentType FOREIGN KEY (PaymentTypeId)
		REFERENCES PaymentType (PaymentTypeId)
)
GO


