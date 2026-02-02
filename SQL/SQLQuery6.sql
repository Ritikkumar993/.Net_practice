use Collage;

-- Q1 id+Name{3}
select CONCAT(Id, SUBSTRING(Name,1,3)) as password from CollageMaster;
-- start to Till r
select SUBSTRING(Name,1,CHARINDEX('r',Name)) as password  from CollageMaster;
--  from r to end
select SUBSTRING(Name,CHARINDEX('r',Name)) as password  from CollageMaster;


alter view v1 as select * from CollageMaster where Gender = 'F';

select Id, Name, PhoneNo from v1;


-------------------------------------------------------------------------------------

CREATE FUNCTION GetDepartmentByName(@name varchar(20))
RETURNS TABLE
AS 
RETURN
(
	SELECT * FROM CollageMaster where Name = @name
);

SELECT * FROM GetDepartmentByName('ritik')


alter FUNCTION GetMaxM1()
RETURNS TABLE
AS
RETURN(select   MAX(M1) as maxM1 from CollageMaster);


create FUNCTION GetMaxM1x()
RETURNS TABLE
AS
RETURN
(
    SELECT MAX(M1) AS maxM1
    FROM CollageMaster
);

select * from GetMaxM1x();


create table #Student(Id int , name varchar(50))

insert into #Student(Id, name)
values
(1,'ritik'),
(2,'aryan'),
(3,'aman');

select * from #Student;


update CollageMaster set Total=M1+M2+M3;
select * from CollageMaster;

alter proc BonousCalculation
as
begin

create table #bonuscalculator (Name nvarchar(50), Total int, Bonous int,Grade nvarchar(10));
insert into #bonuscalculator (Name, Total, Grade) select Name, Total, Grade='Fail' from CollageMaster
update #bonuscalculator set Grade='pass' where Total>=230 
update #bonuscalculator set Bonous=10 where Total>=230 and Total<250

select * from #bonuscalculator
select Count(*) as passCount from #bonuscalculator where Grade='pass';
end

exec BonousCalculation



alter proc PassCalculation
as 
begin

create table #TempStudent(Name nvarchar(50),M1 int) select Name, M1 from CollageMaster;
select Count(*) as beforeCount  from #TempStudent where M1<80;

update #TempStudent set M1=M1+5;

select Count(*) as afterCount from #TempStudent where M1<80;
end

exec PassCalculation



--- Find the second highest salary for an employee
 
 create table Employee(Id INT PRIMARY KEY IDENTITY(1,1), Salary int )
 
 insert into Employee(Salary)
 values
 (80000),
 (85000),
 (75000)

 










-----------------------------------------------------------------------------------------------------------








