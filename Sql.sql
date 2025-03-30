CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    OrderName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    CustomerId INT NOT NULL,
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE
);
GO

CREATE PROCEDURE AddOrder
    @OrderName NVARCHAR(MAX),
    @Quantity INT,
    @CustomerId INT,
    @OrderId INT OUTPUT
AS
BEGIN
    INSERT INTO Orders (OrderName, Quantity, CustomerId, OrderDate)
    VALUES (@OrderName, @Quantity, @CustomerId, GETDATE());
    
    SET @OrderId = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE UpdateOrder
    @OrderId INT,
    @OrderName NVARCHAR(MAX),
    @Quantity INT
AS
BEGIN
    UPDATE Orders
    SET OrderName = @OrderName, Quantity = @Quantity
    WHERE OrderId = @OrderId;
END;
GO

CREATE PROCEDURE DeleteOrder
    @OrderId INT
AS
BEGIN
    DELETE FROM Orders
    WHERE OrderId = @OrderId;
END;
GO

INSERT INTO Customers (FullName, Email)
VALUES ('Sandro Chkhaidze', 'sandrochkhaidze5@gmail.com');
