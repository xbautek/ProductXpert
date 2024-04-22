/*
** Copyright Microsoft, Inc. 1994 - 2000
** All Rights Reserved.
*/

CREATE DATABASE ProductXpert
GO

USE ProductXpert
GO



CREATE TABLE "Employees" (
	"EmployeeID" INTEGER IDENTITY(1,1),
	"LastName" NVARCHAR(255) NOT NULL ,
	"FirstName" NVARCHAR(255) NOT NULL ,
	"Username" NVARCHAR(255) NOT NULL ,
	"Password" NVARCHAR(255) NOT NULL ,
	CONSTRAINT "PK_Employees" PRIMARY KEY  
	(
		"EmployeeID"
	)
);

GO

CREATE TABLE "Customers" (
	"CustomerID" INTEGER IDENTITY(1,1),
	"CompanyName" NVARCHAR(255) NOT NULL ,
	"ContactName" NVARCHAR(255) NULL ,
	"Phone" NVARCHAR(255) NULL ,
	"Email" NVARCHAR(255) NULL ,
	CONSTRAINT "PK_Customers" PRIMARY KEY  
	(
		"CustomerID"
	)
);

GO

CREATE TABLE "Materials" (
	"MaterialID" INT IDENTITY(1,1),
    "MaterialName" NVARCHAR(255) NOT NULL,
    "Description" NVARCHAR(255),
    "Price" DECIMAL(10, 2) NOT NULL,
    "Weight" DECIMAL(10, 2) NOT NULL,
	CONSTRAINT "PK_Materials" PRIMARY KEY  
	(
		"MaterialID"
	)
);

GO

CREATE TABLE "Products" (
	"ProductID" INT IDENTITY(1,1),
	"MaterialID" INTEGER NOT NULL,
	"ProductName" nvarchar (40) NOT NULL ,
	"Description" varchar(100) NULL ,
	"UnitPrice" DECIMAL(10, 2) NULL DEFAULT (0),
	"Amount" INTEGER NULL DEFAULT (0),
	"MinimalAmount" INTEGER NULL,
	CONSTRAINT "PK_Products" PRIMARY KEY  
	(
		"ProductID"
	),
	CONSTRAINT "FK_Products_Materials" FOREIGN KEY 
	(
		"MaterialID"
	) REFERENCES "Materials" (
		"MaterialID"
	)
);

GO

CREATE TABLE "Orders" (
	"OrderID" INT IDENTITY(1,1),
	"CustomerID" INTEGER NOT NULL,
	"ProductID" INTEGER NOT NULL,
	"OrderDate" DATETIME NULL,
	"Amount" INTEGER NOT NULL,
	"OrderStatus" NVARCHAR(255) NULL,
	CONSTRAINT "PK_Orders" PRIMARY KEY  
	(
		"OrderID"
	),
	CONSTRAINT "FK_Orders_Customers" FOREIGN KEY 
	(
		"CustomerID"
	) REFERENCES "Customers" (
		"CustomerID"
	),
	CONSTRAINT "FK_Orders_Products" FOREIGN KEY 
	(
		"CustomerID"
	) REFERENCES "Products" (
		"ProductID"
	)
);

GO

INSERT INTO Customers ("CompanyName", "ContactName", "Phone", "Email")
VALUES 
    ('ABC Company', 'John Smith', '123-456-7890', 'john@example.com'),
    ('XYZ Corporation', 'Jane Doe', '987-654-3210', 'jane@example.com'),
    ('123 Inc.', 'Michael Johnson', '555-555-5555', 'michael@example.com'),
    ('Smith & Co.', 'Emily Williams', '111-222-3333', 'emily@example.com'),
    ('ACME Ltd.', 'David Brown', '999-888-7777', 'david@example.com');

INSERT INTO Materials ("MaterialName", "Description", "Price", "Weight")
VALUES 
    ('Steel', 'High quality steel', 25.00, 10.5),
    ('Aluminum', 'Lightweight aluminum', 15.50, 5.2),
    ('Plastic', 'Durable plastic material', 10.75, 3.0),
    ('Copper', 'Conductive copper material', 30.25, 8.9),
    ('Wood', 'Natural wood material', 20.00, 12.3);

INSERT INTO Products ("MaterialID", "ProductName", "Description", "UnitPrice", "Amount", "MinimalAmount")
VALUES 
    (1, 'Steel Bolt', 'Heavy-duty bolt made of steel', 2.50, 100, 20),
    (2, 'Aluminum Plate', 'Lightweight aluminum plate', 5.75, 50, 10),
    (3, 'Plastic Gear', 'Durable plastic gear for machinery', 3.25, 75, 15),
    (4, 'Copper Wire', 'Conductive copper wire for electrical purposes', 8.50, 200, 30),
    (5, 'Wood Plank', 'Natural wood plank for construction', 15.00, 30, 5);

INSERT INTO Orders ("CustomerID", "ProductID", "OrderDate", "Amount", "OrderStatus")
VALUES 
    (1, 1, '2024-04-22', 50, 'Pending'),
    (1, 2, '2024-04-22', 30, 'Pending'),
    (1, 3, '2024-04-22', 20, 'Pending'),
    (1, 4, '2024-04-22', 100, 'Pending'),
    (1, 5, '2024-04-22', 10, 'Pending');