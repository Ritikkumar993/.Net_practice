use [Sales];

CREATE TABLE Sales_Raw

(

    OrderID INT,

    OrderDate VARCHAR(20),

    CustomerName VARCHAR(100),

    CustomerPhone VARCHAR(20),

    CustomerCity VARCHAR(50),

    ProductNames VARCHAR(200),   -- Multiple products comma-separated

    Quantities VARCHAR(100),     -- Multiple quantities comma-separated

    UnitPrices VARCHAR(100),     -- Multiple prices comma-separated

    SalesPerson VARCHAR(100)

);


INSERT INTO Sales_Raw VALUES

(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai',

 'Laptop,Mouse', '1,2', '55000,500', 'Anitha'),

 

(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore',

 'Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),

 

(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai',

 'Laptop', '1', '54000', 'Suresh'),

 

(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad',

 'Monitor,Mouse', '1,1', '12000,500', 'Anitha'),

 

(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore',

 'Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');


 select * from Sales_Raw;





create table CustomerMaster(
    Id int Primary Key identity(1,1),
    CustomerName nvarchar(50),
    CustomerPhoneNo nvarchar(10),
    CustomerCity nvarchar(50),
);
insert into CustomerMaster(CustomerName, CustomerPhoneNo, CustomerCity) values
('Ravi Kumar','9876543210','Chennai'),
('Priya Sharma','9123456789','Bangalore'),
('John Peter','9988776655','Hyderabad');





create table ProductMaster(
    Id int Primary key identity(1,1),
    ProductName nvarchar(50),
    ProductPrice int,
); 
insert into ProductMaster(ProductName,ProductPrice) values
('Laptop1',55000),
('Laptop2',54000),
('Laptop3',56000),
('Mouse',500),
('Keyboard',15000),
('Monitor',12000);




create table salesPersonMaster(
    Id int Primary key identity(1,1),
    SName nvarchar(50),
);
insert into salesPersonMaster(SName)values
('Anitha'),
('Suresh');


create table SalesDetails(
     Id int Primary key identity(101,1),
     Date Date,
     CustomerId int REFERENCES CustomerMaster(Id)  , 
     SalesPersonId int REFERENCES salesPersonMaster(Id),
);
insert into SalesDetails(Date,CustomerId,SalesPersonId) values
('2024-01-05',1,1),
('2024-01-06',2,1),
('2024-01-10',1,2),
('2024-02-01',3,1),
('2024-02-10',2,2);

create table OrderDetails(
     Id int Primary key identity(1,1),
     OrderId int REFERENCES SalesDetails(Id),
     ProductId int REFERENCES ProductMaster(Id),
     Quantity int,
);
insert into OrderDetails(OrderId,ProductId,Quantity) values
(101,1,1),
(101,4,2),
(102,5,1),
(102,4,1),
(103,2,1),
(104,6,1),
(104,4,1),
(105,3,1),
(105,5,1);




select * from CustomerMaster
select * from ProductMaster;
select * from salesPersonMaster;
select * from SalesDetails;
select * from OrderDetails;

select * from Sales_Raw;


--2

select c.CustomerName, Sum(p.ProductPrice*Quantity) as Total from  OrderDetails od
inner join SalesDetails sd
on sd.Id=od.OrderId
inner join CustomerMaster c
on c.Id=sd.CustomerId
inner join ProductMaster p 
on p.Id = od.ProductId   
Group By OrderId 
Order By Total desc 
offset 2 Rows
fetch Next 1 Row only;

---3

select s.SName,
    Sum(p.ProductPrice*od.Quantity) as TotalSales
from salesPersonMaster s
inner join SalesDetails sd
on s.Id=sd.SalesPersonId
inner join OrderDetails od
on sd.Id = od.OrderId
inner join ProductMaster p
on p.Id=od.ProductId
group by s.SName
having sum(p.ProductPrice*od.Quantity)>60000;


-- 4

select 
    c.CustomerName,
    sum(p.ProductPrice*od.Quantity) as TotalSpend
from CustomerMaster c
inner join SalesDetails sd
on c.Id=sd.CustomerId
inner join OrderDetails od
on sd.Id=od.OrderId
inner join ProductMaster p
on p.Id=od.ProductId
Group by c.CustomerName
having  sum(p.ProductPrice*od.Quantity)>
(
    select AVG(customTotal)
    from (
        select 
            sum(p2.ProductPrice*od2.Quantity) as customTotal
            from SalesDetails sd2
            inner join OrderDetails od2
            on sd2.Id=od2.OrderId
            inner join ProductMaster p2
            on p2.Id=od2.ProductId
            Group by sd2.CustomerId
    ) as AvgT
);


---5

select Upper(c.CustomerName) as name
from CustomerMaster c
inner join SalesDetails sd
on c.Id=sd.CustomerId
where YEAR(sd.Date)=2024 and Month(sd.Date)=1;


















