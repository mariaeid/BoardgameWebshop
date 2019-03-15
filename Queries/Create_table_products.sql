CREATE TABLE [dbo].[Products]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(max) NOT NULL,
    [Price] INT NOT NULL,
    [Quantity] NVARCHAR(max) NOT NULL,
    [Description] NVARCHAR(max),
    [Image] NVARCHAR(max),
    [Category] NVARCHAR(max)
)
