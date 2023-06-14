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