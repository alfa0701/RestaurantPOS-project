--collect Order details by OrderID

 SELECT o.OrderId, e.FirstName, m.MenuName, od.qty, m.Price
 FROM [Order] as o
	INNER JOIN [Employee] as e
	on o.EmpId = e.EmpId
	INNER Join [OrderDetail] as od
	on o.OrderId = od.OrderId
	INNER JOIN [Menu] as m
	on m.MenuId = od.MenuId
	Where od.OrderId = 1;


---display menu Item and Price on order page
SELECT MenuName, Price from Menu



