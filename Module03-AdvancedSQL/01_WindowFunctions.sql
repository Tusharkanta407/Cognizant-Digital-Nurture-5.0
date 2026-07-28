-- ==========================================
-- Module 03 - Advanced SQL: Exercise 1
-- Task: Ranking and Window Functions
-- ==========================================

-- 1. Setup Temporary Schema and Sample Data for evaluation
IF OBJECT_ID('tempdb..#Products') IS NOT NULL DROP TABLE #Products;

CREATE TABLE #Products (
    ProductId INT IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

INSERT INTO #Products (ProductName, Category, Price) VALUES
('Premium Laptop', 'Electronics', 1200.00),
('Standard Laptop', 'Electronics', 800.00),
('Gaming Laptop', 'Electronics', 1200.00), -- Price tie
('Budget Phone', 'Electronics', 300.00),
('Wireless Mouse', 'Electronics', 50.00),
('Ergonomic Chair', 'Furniture', 250.00),
('Executive Desk', 'Furniture', 450.00),
('Standing Desk', 'Furniture', 450.00), -- Price tie
('Basic Stool', 'Furniture', 40.00);

-- 2. Implementation & Analysis using CTE (Common Table Expression)
WITH RankedProducts AS (
    SELECT 
        Category,
        ProductName,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM #Products
)
SELECT 
    Category,
    ProductName,
    Price,
    RowNum,
    RankNum,
    DenseRankNum
FROM RankedProducts
WHERE DenseRankNum <= 3; -- Filters for top 3 in each category

/*
  NOTE ON TIE HANDLING:
  - ROW_NUMBER() assigns a strict sequential number (e.g., 1, 2, 3) ignoring ties.
  - RANK() assigns the same rank to ties but skips subsequent numbers (e.g., 1, 1, 3).
  - DENSE_RANK() assigns the same rank to ties without skipping numbers (e.g., 1, 1, 2).
*/