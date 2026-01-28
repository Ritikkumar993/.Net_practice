use Collage;
Alter Table CollageMaster add Gender nvarchar(10);
Alter Table CollageMaster add M1 int;
Alter Table CollageMaster add M2 int;

Alter Table CollageMaster add M3 int;
Alter Table CollageMaster add Total int;

Select * from CollageMaster;

-- 1) print the phone number of the room no 1 students
Select c.Name, c.PhoneNo from CollageMaster c inner join Hostel2 h on c.Id=h.CollegeId where h.RoomNo=102;

-- 2) List of male or Female students in hostel
Select c.Name from CollageMaster c inner join Hostel2 h on c.Id=h.CollegeId where c.Gender='F';

Select c.Name from CollageMaster c inner join Hostel2 h on c.Id=h.CollegeId where c.Gender='M';

-- 3) List of hostel students who score 100 in any of the exam
Select c.Name from CollageMaster c inner join Hostel2 h on c.Id=h.CollegeId where c.M1=100 or c.M2=100 or c.M3=100;

-- 4)
Select * from CollageMaster c inner join Hostel2 h on c.Id=h.CollegeId where h.RoomNo=102;

-- 5) 
Select AVG(c.M1) as Average_marks from CollageMaster c inner join Hostel2 h on c.Id=h.CollegeId where h.RoomNo=102;

create table BHostel(
	Id int IDENTITY(1,1) NOT NULL ,
	RoomNo int  NOT NULL ,
	StudentId int  NOT NULL ,
);

create table GHostel(
	Id int IDENTITY(1,1) NOT NULL ,
	RoomNo int  NOT NULL ,
	StudentId int  NOT NULL ,
);

create table BookMastery(
	Id int IDENTITY(1,1) NOT NULL ,
	Book_Name nvarchar(50)  NOT NULL ,
	Author nvarchar(50)	NOT NULL,
	ISBN nvarchar(18) NOT NULL,
	Price int NOT NULL,
);

create table Library(
	Id int IDENTITY(1,1) NOT NULL ,
	BookId int  NOT NULL ,
	TakenBy int	NOT NULL,
	IssueDate DateTime NOT NULL,
);


-- 1) print students who have taken java book from library
-- select * From CollageMaster c inner join Library l on c.Id=l.TakenBy where l.BookId=(select Id from BookMastery where Book_Name='java');

select * From CollageMaster c inner join Library l on c.Id=l.TakenBy inner join BookMastery b on l.BookId=b.Id where b.Book_Name='java';
-- 2)how many books is taken by the person who scored 100

select c.ID as Person, Count(l.TakenBy) as TotalCount 
from CollageMaster c 
inner join Library l 
on c.Id=l.TakenBy 
where c.M1=100 or c.M2=100 or c.M3=100 
Group By c.ID, l.TakenBy;

-- 3) how many student from room no 1 taken the python book?

select * from CollageMaster c 
inner join BHostel bh
on c.Id=bh.StudentId

inner Join Library l 
on l.TakenBy=bh.StudentId

inner join BookMastery b
on l.BookId = b.Id

where bh.RoomNo=101;

-- 4) which department student have taken the python book?

select c.Department as Dept, c.Name as name from CollageMaster c 
inner join Library l
on c.Id=l.TakenBy

inner join BookMastery b
on l.BookId=b.Id

where b.Book_Name='Python';

-- 5) print the phoneNoof the student who took java book?
select c.PhoneNo as PhoneNo from CollageMaster c
inner join Library l
on c.id=l.TakenBy
inner join BookMastery b
on l.BookId=b.Id
where b.Book_Name='java';


select c.Name, b.Book_name, b.ISBN  from CollageMaster c
inner join Library l
on c.id = l.TakenBy
inner join BookMastery b
on b.Id=l.BookId
where c.Name='Tamanna';



SELECT Name, Book_Name, ISBN
FROM  CollageMaster INNER JOIN Library 
ON CollageMaster.Id = Library.TakenBy INNER JOIN
         BookMastery 
ON Library.BookId = BookMastery.Id where CollageMaster.Name='tamanna';



-- left Join
select c.Id, COALESCE(bh.RoomNo, gh.RoomNo) as RoomNo  from CollageMaster c 
	left join BHostel bh on c.Id=bh.StudentId 
	left join GHostel gh on c.Id=gh.StudentId;

create table CollageMastery2(
	Id int identity(1,1) NOT NULL ,
	Name nvarchar(50) NOT NULL ,
	CourseId int NOT NULL ,
);

create table Course(
	Id int IDENTITY(1,1) NOT NULL,
	Course_Name nvarchar(50) NOT NULL,
);

select   c.Course_Name, c2.Name   from CollageMastery2 c2
	Right join Course c
	on c.Id= c2.CourseId;






