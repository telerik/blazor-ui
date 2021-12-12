CREATE TABLE [dbo].[ProductLinks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstProduct] INT NOT NULL,
	[SecondProduct] INT NOT NULL, 
    CONSTRAINT [FK_ProductLinks_Products_1] FOREIGN KEY ([FirstProduct]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_ProductLinks_Products_2] FOREIGN KEY ([SecondProduct]) REFERENCES [Products]([Id])
)
