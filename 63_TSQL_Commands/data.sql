--Common Table Expressions (CTEs)

-- Example of a CTE to calculate the average price per category
WITH AveragePriceByCategory AS (
  SELECT CategoryID, AVG(Price) AS AvgPrice
  FROM Products
  GROUP BY CategoryID
)
SELECT CategoryID, AvgPrice
FROM AveragePriceByCategory;


-- Example of a CTE to find the top 5 most expensive products in each category
WITH Top5Products AS (
  SELECT ProductID, CategoryID, Price,
         ROW_NUMBER() OVER (PARTITION BY CategoryID ORDER BY Price DESC) AS Rank
  FROM Products
)
SELECT ProductID, CategoryID, Price
FROM Top5Products
WHERE Rank <= 5;


--Using PIVOT and UNPIVOT

-- Example of UNPIVOT
SELECT ProductID, Attribute, Value
FROM (SELECT ProductID, Color, Size
      FROM Products) AS SourceTable
UNPIVOT (
  Value FOR Attribute IN (Color, Size)
) AS UnpivotTable;

-- Example of PIVOT with dynamic column names
DECLARE @DynamicColumns NVARCHAR(MAX);
SET @DynamicColumns = N'[2018], [2019], [2020]';

DECLARE @SQL NVARCHAR(MAX);
SET @SQL = N'SELECT *
             FROM (SELECT ProductID, OrderYear, Quantity
                   FROM SalesReport) AS SourceTable
             PIVOT (
               SUM(Quantity)
               FOR OrderYear IN (' + @DynamicColumns + ')
             ) AS PivotTable;';

EXEC sp_executesql @SQL;


--Window Functions

-- Example of RANK() window function
SELECT EmployeeID, FirstName, LastName, Salary,
       RANK() OVER (ORDER BY Salary DESC) AS Rank
FROM Employees;

-- Example of NTILE() window function
SELECT EmployeeID, FirstName, LastName, Salary,
       NTILE(4) OVER (ORDER BY Salary) AS Quartile
FROM Employees;

-- Example of ROW_NUMBER() window function
SELECT EmployeeID, FirstName, LastName, Salary,
       ROW_NUMBER() OVER (ORDER BY Salary DESC) AS RowNumber
FROM Employees;

--Recursive Queries

-- Example of a recursive CTE to find the total number of descendants for each employee
WITH EmployeeDescendants AS (
  SELECT EmployeeID, 1 AS DescendantCount
  FROM Employees
  UNION ALL
  SELECT e.EmployeeID, ed.DescendantCount + 1
  FROM Employees e
  INNER JOIN EmployeeDescendants ed ON e.ManagerID = ed.EmployeeID
)
SELECT EmployeeID, SUM(DescendantCount) AS TotalDescendants
FROM EmployeeDescendants
GROUP BY EmployeeID;

-- Example of a recursive CTE to calculate the factorial of a number
WITH FactorialCTE AS (
  SELECT 1 AS n, 1 AS Factorial
  UNION ALL
  SELECT n + 1, (n + 1) * Factorial
  FROM FactorialCTE
  WHERE n < 5
)
SELECT * FROM FactorialCTE;

--TRY…CATCH

-- Example of TRY...CATCH with transaction control
BEGIN TRY
  BEGIN TRANSACTION;
  -- Your T-SQL code here
  COMMIT TRANSACTION;
END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION;
  -- Error handling code here
  SELECT ERROR_NUMBER() AS ErrorNumber,
         ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

-- Example of TRY...CATCH with error logging
BEGIN TRY
  -- Your T-SQL code here
END TRY
BEGIN CATCH
  INSERT INTO ErrorLog (ErrorNumber, ErrorMessage, ErrorTime)
  VALUES (ERROR_NUMBER(), ERROR_MESSAGE(), GETDATE());
END CATCH;

--MERGE Statement

-- Example of MERGE to synchronize two tables
MERGE INTO Products AS Target
USING UpdatedProducts AS Source
ON Target.ProductID = Source.ProductID
WHEN MATCHED THEN
    UPDATE SET Target.ProductName = Source.ProductName,
               Target.Price = Source.Price
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Price)
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

-- Example of MERGE with OUTPUT
DECLARE @MergeOutput TABLE (
    Action NVARCHAR(10),
    ProductID INT,
    OldProductName NVARCHAR(50),
    NewProductName NVARCHAR(50),
    OldPrice DECIMAL(10, 2),
    NewPrice DECIMAL(10, 2)
);

MERGE INTO Products AS Target
USING UpdatedProducts AS Source
ON Target.ProductID = Source.ProductID
WHEN MATCHED THEN
    UPDATE SET Target.ProductName = Source.ProductName,
               Target.Price = Source.Price
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProductID, ProductName, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Price)
WHEN NOT MATCHED BY SOURCE THEN
    DELETE
OUTPUT $action,
       DELETED.ProductID,
       DELETED.ProductName, INSERTED.ProductName,
       DELETED.Price, INSERTED.Price
INTO @MergeOutput;

SELECT * FROM @MergeOutput;

--FORMAT Function

-- Example of FORMAT for displaying dates in different formats
DECLARE @SampleDate DATETIME = '2023-05-01';

SELECT FORMAT(@SampleDate, 'MM/dd/yyyy') AS USDateFormat,        -- '05/01/2023'
       FORMAT(@SampleDate, 'dd/MM/yyyy') AS UKDateFormat,        -- '01/05/2023'
       FORMAT(@SampleDate, 'yyyy-MM-dd') AS ISODateFormat,       -- '2023-05-01'
       FORMAT(@SampleDate, 'D', 'en-US') AS LongDateUS,          -- 'Monday, May 01, 2023'
       FORMAT(@SampleDate, 'D', 'en-GB') AS LongDateUK;          -- '01 May 2023'

-- Example of FORMAT for displaying numbers with different formats
DECLARE @SampleNumber DECIMAL(10, 2) = 1234567.89;

SELECT FORMAT(@SampleNumber, 'N') AS NumberFormat,               -- '1,234,567.89'
       FORMAT(@SampleNumber, 'C', 'en-US') AS CurrencyFormatUS,  -- '$1,234,567.89'
       FORMAT(@SampleNumber, 'C', 'en-GB') AS CurrencyFormatUK,  -- '£1,234,567.89'
       FORMAT(@SampleNumber, 'P', 'en-US') AS PercentageFormat;  -- '123,456,789.00 %'


--Filtered Indexes

-- Example of creating a filtered index for active customers
CREATE INDEX IX_Customers_Active
ON Customers (CustomerID)
WHERE IsActive = 1;

-- Example of creating a filtered index for products with a specific price range
CREATE INDEX IX_Products_PriceRange
ON Products (ProductID)
WHERE Price BETWEEN 100 AND 500;

--Dynamic SQL

-- Example of Dynamic SQL
DECLARE @ColumnName NVARCHAR(50) = 'CategoryID';
DECLARE @TableName NVARCHAR(50) = 'Products';
DECLARE @SQL NVARCHAR(MAX);

SET @SQL = 'SELECT ' + QUOTENAME(@ColumnName) + ' FROM ' + QUOTENAME(@TableName) + ';';
EXEC sp_executesql @SQL;

-- Example of Dynamic SQL with parameterized queries
DECLARE @CustomerID INT = 1;
DECLARE @SQL NVARCHAR(MAX);
DECLARE @ParamDefinition NVARCHAR(MAX);

SET @SQL = N'SELECT * FROM Customers WHERE CustomerID = @CustomerID;';
SET @ParamDefinition = N'@CustomerID INT';

EXEC sp_executesql @SQL, @ParamDefinition, @CustomerID = @CustomerID;


-- Temporal Tables

-- Example of creating a temporal table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    HireDate DATE,
    Salary DECIMAL(10, 2),
    SysStartTime DATETIME2 GENERATED ALWAYS AS ROW START,
    SysEndTime DATETIME2 GENERATED ALWAYS AS ROW END,
    PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeesHistory));


-- Example of querying historical data from a temporal table
DECLARE @TargetDate DATETIME2 = '2022-01-01T00:00:00';

SELECT EmployeeID, FirstName, LastName, HireDate, Salary
FROM Employees
FOR SYSTEM_TIME AS OF @TargetDate;