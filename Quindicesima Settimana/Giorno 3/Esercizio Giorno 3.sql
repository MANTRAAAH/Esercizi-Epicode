select COUNT(*) as NumeroTotaleOrdini from Orders;

select COUNT (*) as NumeroTotaleClienti from Customers;

select COUNT (*) as NumeroTotaleClienti from Customers where City = 'London';

select AVG (freight) as MediaSpeseTrasporto from Orders;

select AVG (freight) as MediaTrasportoCliente from Orders where CustomerID = 'BOTTM';

SELECT CustomerID, SUM(freight) AS TotaleSpeseTrasporto FROM Orders GROUP BY CustomerID;

SELECT City, COUNT(*) AS NumeroClienti FROM Customers GROUP BY City;

SELECT OrderId, SUM(UnitPrice * Quantity) AS TotaleOrdine
FROM [Order Details]
GROUP BY OrderId;

SELECT OrderId, SUM(UnitPrice * Quantity) AS TotaleOrdine 
FROM [Order Details] where OrderId = 10248
GROUP BY OrderId;

SELECT CategoryId , COUNT(*) AS NumeroProdotti FROM Products GROUP BY CategoryId;

SELECT ShipCountry, COUNT(*) AS NumeroOrdini FROM Orders GROUP BY ShipCountry;

SELECT shipCountry,AVG(Freight) AS MediaSpeseTrasporto FROM Orders Group BY ShipCountry;




