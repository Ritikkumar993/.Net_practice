use TopBrains;


create table students(
	Id int identity(1,1) Primary key,
	Name nvarchar(50),
	M1 int,
	M2 int
);

Insert into students(Name, M1,M2) values
('mari',75,83),
('Raman',66,91)


update students set M1=M1+M2;
update students set M2=M1-M2;
update students set M1=M1-M2;

select * from students;

create table Employees(
	Id int Identity(1,1) Primary key,
	Name nvarchar(50),
	Dept nvarchar(50),
	Salary int,
	MgId int
);

insert into 

use collage;

create Proc sp_getStudentDetails
as
begin
select Name, Department from CollageMaster
end

exec sp_getStudentDetails


create table ContactDetails(
	Name nvarchar(50),
	Email nvarchar(30),
	FatherPhoneNo nvarchar(10),
	MotherPhoneNo nvarchar(10),
	LandLineNo nvarchar(4),
	FriendsPhoneNo nvarchar(10)
);

insert into ContactDetails(Name,Email,FatherPhoneNo,MotherPhoneNo,LandLineNo,FriendsPhoneNo)values
('Mari',NULL,'1234567890',NULL,NULL,NULL),
('Monu','monu@gmail.com',NULL,NULL,NULL,NULL),
('Sonu',NULL,NULL,'1029384756',NULL,NULL),
('Aman',NULL,NULL,NULL,'1234',NULL),
('Arun',NULL,NULL,NULL,NULL,NULL)


select Name, ISNULL(Email,'Email does not exist') from ContactDetails
select Name, ISNULL(FatherPhoneNo,'FatherPhoneNo does not exist') from ContactDetails;
select Name, ISNULL(MotherPhoneNo,'MotherPhoneNo does not exist') from ContactDetails;
select Name, ISNULL(LandLineNo,'LandLineNo does not exist') from ContactDetails;
select Name, ISNULL(FriendsPhoneNo,'FriendsPhoneNo does not exist') from ContactDetails;


select Name, coalesce(Email,FatherPhoneNo,MotherPhoneNo,LandLineNo,FriendsPhoneNo,'No contact Info') as Contact from ContactDetails;

select * from ContactDetails;

use collage

create proc sp_getStudentDetailsWith
@gender varchar(1),
@dept varchar(50)
as 
begin
select * from CollageMaster where Gender = @gender and Department=@dept;
end;

exec sp_getStudentDetailsWith 'M', 'cse'


create proc sp_getStudentWithInputOutputParameter
	@gender varchar(1),
	@TotalCount int out
as 
begin
	begin try
		select @TotalCount = Count(*) from CollageMaster where Gender=@gender;
		print('Counted successfully');
	end try
	begin catch
		print('Error occured');
		print ERROR_MESSAGE()
	end catch
end

declare @count int;
exec sp_getStudentWithInputOutputParameter 'M', @count output;
print(@count);







