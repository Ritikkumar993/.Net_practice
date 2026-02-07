use TopBrains;

EmployeeSalesRaw
----------------------------------------------------
EmpId
EmpName
Department
Email
SaleMonth
SaleYear
SaleAmount

-- Q1

create table Department
(
	DeptId int identity(1,1) primary key,
	DeptName varchar(50)
);

drop table Employee;
create table Employee
(
	EmpId int identity(1,1) primary key,
	EmpName varchar(50),
	DeptId int ,
	Email varchar(50),
	Foreign key (DeptId) REFERENCES  Department(DeptId)
);

drop table Sales;

create table Sales
(
	SalesId int identity(1,1) primary key,
	EmpId int,
	SalesMonth int,
	SalesYear int,
	SalesAmount int,
	Foreign key (EmpId) REFERENCES Employee(EmpId)
);

-- Q2
alter table Employee
add BonusPoints  int default 0;

--- Q3
alter table Employee
add Constraint bonus_check
check (BonusPoints between 0 and 100);


insert into Department(DeptName)values
('cse'),
('mca'),
('bca'),
('bba'),
('llb'),
('ds')

insert into Employee(EmpName,DeptId,Email,BonusPoints)values
('mari',1,'mari@gmail.com',100),
('sonu',3,'sonu@gmail.com',80),
('aman',4,'aman@gmail.com',100),
('rohan',2,'rohan@gmail.com',90),
('golu',3,'golu@gmail.com',85),
('sam',1,'sam@gmail.com',80),
('robiin',1,'robiin@gmail.com',90),
('raman',1,'raman@gmail.com',100)

insert into Sales(EmpId,SalesMonth,SalesYear,SalesAmount) values
(1,2,2026,65000),
(2,2,2026,45000),
(3,2,2026,55000),
(4,2,2026,45000),
(5,2,2026,55000),
(6,2,2026,45000),
(7,2,2026,55000),
(8,2,2026,65000)

select * from Sales;

insert into Sales(EmpId,SalesMonth,SalesYear,SalesAmount) values
(4,1,2026,5000),
(7,1,2026,6000)


--- Q4

select
	e.EmpName, 
	d.DeptName,
	s.SalesMonth,
	s.SalesYear,
	s.SalesAmount

from Sales s
inner join Employee e
on s.EmpId=e.EmpId
inner join Department d
on e.DeptId=d.DeptId


-- Q5
select 
	e.EmpId,
	e.EmpName,
	Sum(s.SalesAmount) as Total
from Employee e
	inner join Sales s 
	on e.EmpId =s.EmpId
where 
	s.SalesYear =year(getdate())
group by  e.EmpId, e.EmpName;


-- Q6
select 
	Concat(Left(e.EmpName,3),Left(d.DeptName,2),e.EmpId) as UserName 

from Employee e
inner join Department d
on e.DeptId=d.DeptId;


-- Q7

select 
	e.EmpId,
	e.EmpName,
	sum(s.SalesAmount) as Total
from Employee e
	inner join Sales s
	on e.EmpId=s.EmpId
Group By
	e.EmpId, e.EmpName
Having 
	sum(s.SalesAmount) > (
		select
			AVG(Totalsale)
		from (
			select	
				EmpId,
				sum(SalesAmount) as Totalsale
			from Sales
			Group by EmpId
			)  as emp
		)


-- Q8


select 
	e.EmpName,
	s1.SalesAmount,
	'High' as category

from Sales s1
	inner join Employee e
	on s1.EmpId = e.EmpId
where s1.SalesAmount >50000

union

select 
	e.EmpName,
	s1.SalesAmount,
	'Low' as category

from Sales s1
	inner join Employee e
	on s1.EmpId = e.EmpId
where s1.SalesAmount <10000
order by SalesAmount



-- Q9
create TRIGGER trgUpdateBonusPoints
on Sales
After insert
as 
begin
	set nocount on;

	update e
		set e.BonusPoints = 
		case  
			when i.SalesAmount >= 50000 then e.BonusPoints +10 
			when i.SalesAmount >= 20000 then e.BonusPoints +5
			else e.BonusPoints
		end
	from Employee e
	inner join inserted i
	on e.EmpId = i.EmpId
	where e.BonusPoints <=100;
end;

insert into Sales(EmpId,SalesMonth,SalesYear,SalesAmount) values
(8,1,2026,5000),

-- Q10
select 
	e.EmpName,
	d.DeptName,
	COALESCE(sum(s.SalesAmount),0)  as totalSales,
	e.BonusPoints,
	case 
		when e.BonusPoints >=50 then 'A'
		when e.BonusPoints between 20 and 49 then 'B'
		else 'C'
	end as Grade
from Employee e
	join Department d 
	on e.DeptId=d.DeptId
	Left join Sales s
	on e.EmpId = s.EmpId
Group by
	e.EmpId, e.EmpName, d.DeptName, e.BonusPoints;