IF DB_ID('DapperDemoDb') IS NULL
BEGIN
    CREATE DATABASE DapperDemoDb;
END;
GO

USE DapperDemoDb;
GO

IF OBJECT_ID('dbo.Products', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(200) NOT NULL,
        Price DECIMAL(10,2) NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Products)
BEGIN
    INSERT INTO dbo.Products (Name, Price)
    VALUES
        (N'Keyboard', 79.99),
        (N'Mouse', 39.50),
        (N'Monitor', 299.00);
END;
GO
