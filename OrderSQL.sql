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


select OrderId, sum(m.price)as amout from menu as m
inner join OrderDetail as od on m.MenuId = od.MenuId
group by od.orderId




select PaymentId, sum(m.price)as amout from menu as m
inner join OrderDetail as od on m.MenuId = od.MenuId
group by od.PaymentId

insert  into Payment (EmpId ,IsPaid) values (1002,0);
update OrderDetail set PaymentId = 10002 where OrderId = 525;

Insert into [Order] (EmpId, OrderDate,TableNumber, GuestCount)
values (1000,CURRENT_TIMESTAMP,5,5);

delete from [Order] where OrderId < 513

SELECT  od.OrderDetailId as Id, m.MenuName as Item, od.qty as Qty,m.Price as Price FROM [Order] as o
 INNER Join [OrderDetail] as od on o.OrderId = od.OrderId
 INNER JOIN [Menu] as m on m.MenuId = od.MenuId Where od.OrderId = 531 and PaymentId is null


SELECT m.MenuName as Item,Count(od.qty) as Qty FROM [Order] as o 
INNER Join [OrderDetail] as od on o.OrderId = od.OrderId
INNER JOIN [Menu] as m on m.MenuId = od.MenuId
inner join [Category]as c
on c.CategoryId = m.CategoryId
Where CategoryName ='Drink' and CAST(OrderDate AS DATE) = '2017-10-11'
Group by m.MenuName
order by qty desc

select  CAST(OrderDate AS DATE) from [Order]where OrderId = 535;

Update [Order] set OrderDate =  '2017-10-10' where CAST(OrderDate AS DATE) = '2017-11-15'

