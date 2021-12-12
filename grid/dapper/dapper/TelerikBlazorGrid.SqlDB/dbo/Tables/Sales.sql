CREATE TABLE [dbo].[Sales]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductId] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[Created] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Sales_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
)
