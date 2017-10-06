CREATE VIEW [dbo].[OrderByTableView]
	AS SELECT m.MenueName, Sum(od.Qty)
FROM dbo.[Order] as o
INNER JOIN dbo.[OrderDetail] as od
ON o.OrderId = od.OrderId
INNER JOIN dbo.[Menue] as m
ON m.MenuId = od.MenuId
Group by od.MenuId ;

