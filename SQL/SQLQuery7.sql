
use collage;

/*
Create Trigger prevent_table_drop
on database
for DROP_TABLE
as
begin
*/



CREATE TRIGGER prevent_update
ON CollageMastery2
for UPDATE
AS 
BEGIN
	RAISERROR ('You can not update in this table',16,1);
	ROLLBACK
END;

UPDATE CollageMastery2 SET CourseId = 2 WHERE Id=1;


create table Employees(
	EmpId int identity(1,1) primary key,
	EmpName varchar(100),
	EmpSal Decimal(10,2)
);


create table Employee_Audit (
	EmpId int,
	EmpName varchar(100),
	EmpSal decimal(10,2),
	Audit_Action varchar(100),
	Audit_Timestamp DATETIME
);


CREATE TRIGGER trgAfterInsertEmployee
on Employees
after insert
as 
begin
	set nocount on;

	insert into Employee_Audit (EmpId,EmpName, EmpSal, Audit_Action, Audit_Timestamp)
	select 
		i.EmpId,
		i.EmpName,
		i.EmpSal,
		'Inserted Record',
		getdate()
	from 
		inserted as i
end
go


insert into Employees(EmpName, EmpSal) values
('Roman',80000)

select * from Employees;

select * from Employee_Audit;



create TRIGGER trgAfterUpdateEmployee
on Employees
after update
as 
begin
	set nocount on;

	insert into  Employee_Audit (EmpId,EmpName, EmpSal, Audit_Action, Audit_Timestamp)
	select 
		i.EmpId,
		i.EmpName,
		i.EmpSal,
		'updated Record',
		getdate()
	from 
		inserted as i
end
go

update Employees set EmpSal=120000.00 where EmpId=1;

drop table Orders;

create table Orders(
	OrderId int identity(1,1) primary key,
	ProdName varchar(100),
	ProdPrice decimal(10,2),
	status nvarchar(100)

);

drop table Delevery_Actions;

create table Delevery_Actions(
	OrderId int,
	ProdName varchar(100),
	ProdPrice decimal(10,2),
	status nvarchar(100),
	Audit_Action varchar(100),
	Audit_Timestamp DATETIME
);

drop trigger TriggerAfterUpdate

create trigger TriggerAfterUpdate
on Orders
after update 
as 
begin
	set nocount on;

	insert into Delevery_Actions(OrderId,ProdName,ProdPrice,status,Audit_Action,Audit_Timestamp)
	select 
		u.OrderId,
		u.ProdName,
		u.ProdPrice,
		u.status,
		'update status',
		getdate()
	from 
		inserted as u
end;
go
		
insert into Orders(ProdName,ProdPrice,status)values
('IEM Headphone',850,'Transit')

select * from Orders;
select * from Delevery_Actions;

update Orders set status='shiped' where OrderId=1;



