﻿CREATE TABLE [Customers]
(
[Id] INT NOT NULL IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
[Address] VARCHAR(200) NOT NULL,
[VIP] BIT NOT NULL,
CONSTRAINT [PK_Customers] PRIMARY KEY([Id])
)

CREATE TABLE [Orders]
(
[Number] INT NOT NULL IDENTITY (1,1),
[Description] VARCHAR(500),
[CustomerId] INT NOT NULL,
CONSTRAINT [PK_Orders] PRIMARY KEY ([Number]),
CONSTRAINT [FK__CustomerId] FOREIGN KEY ([CustomerId])
	REFERENCES [Customers] ([Id])
)