CREATE FUNCTION [dbo].[sfGetLinkedProductsForProductId]
(
	@Id int
)
RETURNS TABLE AS RETURN
(
	SELECT DISTINCT *
		FROM
		(
			SELECT
				[p1].[Id],
				[p1].[Name],
				[p1].[Quantity],
				[p1].[OnSale],
				[p1].[Category],
				[p1].[Created]
			FROM [dbo].[Products] p
			LEFT OUTER JOIN [dbo].[ProductLinks] pl1
				ON [p].[Id] = [pl1].[FirstProduct]
			RIGHT OUTER JOIN [dbo].[Products] p1
				ON [pl1].[SecondProduct] = [p1].[Id]
			WHERE [p].[Id] = @Id
			UNION
			SELECT
				[p1].[Id],
				[p1].[Name],
				[p1].[Quantity],
				[p1].[OnSale],
				[p1].[Category],
				[p1].[Created]
			FROM [dbo].[Products] p
			LEFT OUTER JOIN [dbo].[ProductLinks] pl1
				ON [p].[Id] = [pl1].[SecondProduct]
			RIGHT OUTER JOIN [dbo].[Products] p1
				ON [pl1].[FirstProduct] = [p1].[Id]
			WHERE [p].[Id] = @Id
		) AS t
)
