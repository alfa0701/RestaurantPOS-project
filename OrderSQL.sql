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


---display orderd menuitems

SELECT  m.MenuName as Item,Count(od.qty) as Qty
 FROM [Order] as o
	INNER JOIN [Employee] as e
	on o.EmpId = e.EmpId
	INNER Join [OrderDetail] as od
	on o.OrderId = od.OrderId
	INNER JOIN [Menu] as m
	on m.MenuId = od.MenuId
	Where od.OrderId = 1
	Group by m.MenuName


---display menu Item and Price on order page
SELECT MenuName, Price from Menu



---------display sold item of the day
select m.MenuName, count(od.Qty)as Qty
from orderdetail as od
inner join menu as m
on od.MenuId = m.MenuId
inner join [Order] as o
on o.orderId= od.OrderId
where CAST(o.OrderDate AS DATE) = '2017-10-08'
group by m.MenuName
order by Qty desc


