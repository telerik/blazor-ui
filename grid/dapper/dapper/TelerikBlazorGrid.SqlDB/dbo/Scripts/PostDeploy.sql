/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Products]
    ([Name], [Quantity], [OnSale], [Category], [Created])
    VALUES
    ('Product 01', 10, 1, 0, DATEADD(day, -273, CURRENT_TIMESTAMP)),
    ('Product 02', 0, 0, 1, DATEADD(day, -10, CURRENT_TIMESTAMP)),
    ('Product 03', 5, 1, 2, DATEADD(day, -15, CURRENT_TIMESTAMP)),
    ('Product 04', 8, 1, 3, DATEADD(day, -100, CURRENT_TIMESTAMP)),
    ('Product 05', 7, 0, 4, DATEADD(day, -16, CURRENT_TIMESTAMP)),
    ('Product 06', 1, 1, 0, DATEADD(day, -15, CURRENT_TIMESTAMP)),
    ('Product 07', 100, 1, 1, DATEADD(day, -199, CURRENT_TIMESTAMP)),
    ('Product 08', 50, 0, 2, DATEADD(day, -185, CURRENT_TIMESTAMP)),
    ('Product 09', 40, 1, 3, DATEADD(day, -255, CURRENT_TIMESTAMP)),
    ('Product 10', 30, 1, 4, DATEADD(day, -113, CURRENT_TIMESTAMP)),
    ('Product 11', 20, 0, 0, DATEADD(day, -165, CURRENT_TIMESTAMP)),
    ('Product 12', 10, 1, 1, DATEADD(day, -65, CURRENT_TIMESTAMP)),
    ('Product 13', 11, 1, 2, DATEADD(day, -4, CURRENT_TIMESTAMP)),
    ('Product 14', 12, 0, 3, DATEADD(day, -333, CURRENT_TIMESTAMP)),
    ('Product 15', 13, 1, 4, DATEADD(day, -48, CURRENT_TIMESTAMP)),
    ('Product 16', 14, 1, 0, DATEADD(day, -14, CURRENT_TIMESTAMP)),
    ('Product 17', 106, 0, 1, DATEADD(day, -1, CURRENT_TIMESTAMP)),
    ('Product 18', 102, 1, 2, DATEADD(day, -15, CURRENT_TIMESTAMP)),
    ('Product 19', 110, 1, 3, DATEADD(day, -133, CURRENT_TIMESTAMP)),
    ('Product 20', 0, 0, 4, DATEADD(day, -144, CURRENT_TIMESTAMP)),
    ('Product 21', 6, 1, 0, DATEADD(day, -154, CURRENT_TIMESTAMP)),
    ('Product 22', 5, 1, 1, DATEADD(day, -21, CURRENT_TIMESTAMP)),
    ('Product 23', 1, 0, 2, DATEADD(day, -221, CURRENT_TIMESTAMP)),
    ('Product 24', 1, 1, 3, DATEADD(day, -11, CURRENT_TIMESTAMP)),
    ('Product 25', 1, 1, 4, DATEADD(day, -1, CURRENT_TIMESTAMP)),
    ('Product 26', 9, 0, 0, DATEADD(day, -165, CURRENT_TIMESTAMP)),
    ('Product 27', 90, 0, 1, DATEADD(day, -194, CURRENT_TIMESTAMP)),
    ('Product 28', 80, 1, 2, DATEADD(day, -154, CURRENT_TIMESTAMP)),
    ('Product 29', 70, 1, 3, DATEADD(day, -121, CURRENT_TIMESTAMP)),
    ('Product 30', 120, 1, 4, DATEADD(day, -111, CURRENT_TIMESTAMP)),
    ('Product 31', 120, 0, 0, DATEADD(day, -138, CURRENT_TIMESTAMP)),
    ('Product 32', 103, 1, 1, DATEADD(day, -188, CURRENT_TIMESTAMP)),
    ('Product 33', 150, 0, 2, DATEADD(day, -194, CURRENT_TIMESTAMP)),
    ('Product 34', 160, 0, 3, DATEADD(day, -166, CURRENT_TIMESTAMP)),
    ('Product 35', 110, 0, 4, DATEADD(day, -136, CURRENT_TIMESTAMP)),
    ('Product 36', 610, 1, 0, DATEADD(day, -168, CURRENT_TIMESTAMP)),
    ('Product 37', 310, 1, 1, DATEADD(day, -115, CURRENT_TIMESTAMP)),
    ('Product 38', 110, 1, 2, DATEADD(day, -117, CURRENT_TIMESTAMP)),
    ('Product 39', 410, 0, 3, DATEADD(day, -142, CURRENT_TIMESTAMP)),
    ('Product 40', 710, 1, 4, DATEADD(day, -182, CURRENT_TIMESTAMP)),
    ('Product 41', 910, 0, 0, DATEADD(day, -128, CURRENT_TIMESTAMP)),
    ('Product 42', 110, 0, 1, DATEADD(day, -19, CURRENT_TIMESTAMP)),
    ('Product 43', 210, 1, 2, DATEADD(day, -113, CURRENT_TIMESTAMP)),
    ('Product 44', 310, 1, 3, DATEADD(day, -147, CURRENT_TIMESTAMP)),
    ('Product 45', 410, 1, 4, DATEADD(day, -175, CURRENT_TIMESTAMP)),
    ('Product 46', 510, 1, 0, DATEADD(day, -138, CURRENT_TIMESTAMP)),
    ('Product 47', 160, 1, 1, DATEADD(day, -185, CURRENT_TIMESTAMP)),
    ('Product 48', 107, 1, 2, DATEADD(day, -167, CURRENT_TIMESTAMP)),
    ('Product 49', 105, 0, 3, DATEADD(day, -141, CURRENT_TIMESTAMP)),
    ('Product 50', 102, 1, 4, DATEADD(day, -115, CURRENT_TIMESTAMP))