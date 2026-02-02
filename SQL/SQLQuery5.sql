USE [collage]
GO
/****** Object:  StoredProcedure [dbo].[uspGetstudentCountByDept]    Script Date: 29-01-2026 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[upsgetstudentbyDept]
           -- Input parameter
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION Trans_One

    insert into BHostel(RoomNo,StudentId) values (23,7)


if @@ROWCOUNT = 0
ROLLBACK TRANSACTION Trans_One

COMMIT TRANSACTION Trans_One

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION Trans_One

END CATCH

END;

exec [dbo].[upsgetstudentbyDept]


-------------------------------------------------------------------------------------------------------------------


--- USE [collage]
GO
/****** Object:  StoredProcedure [dbo].[uspGetstudentCountByDept]    Script Date: 29-01-2026 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[upsgetstudentbyDept]
           -- Input parameter
  
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION Trans_One

update [dbo].[CollageMaster] set Department ='ME' where Department ='BBA'
insert into BHostel (RoomNo,StudentId) values (23,19)


if @@ROWCOUNT = 0
ROLLBACK TRANSACTION Trans_One

COMMIT TRANSACTION Trans_One

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION Trans_One

END CATCH

END;


exec [upsgetstudentbyDept]

--------------------------------------------------------------------------------------------

go
alter PROCEDURE InsertIntoCollageMaster
           -- Input parameter
  
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION Trans_One


insert into CollageMaster(Name, Department, Gender, PhoneNo) values ('Sparsh','CSE','M',8765434576)



declare @StudenstId int
select @StudenstId = Id from CollageMaster where Name='Sparsh'
insert into BHostel(RoomNo, StudentId) values(105,@StudenstId)

if @@ROWCOUNT = 0
ROLLBACK TRANSACTION Trans_One
COMMIT TRANSACTION Trans_One

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION Trans_One

END CATCH

END;


exec [dbo].[InsertIntoCollageMaster]



------------------------------------------------------------------------------------------------------




select * from CollageMaster;

drop CommonHostel;
create table CommonHostel(
    Id int  NOT NULL,
    RoomNo int NOT NULL,
    StudentId int NOT NULL
 );

 INSERT INTO CommonHostel(Id, RoomNo, StudentId) select * from BHostel;




 select * from CollageMaster
 where Id between 5 AND 10
 UNION 
 select * from CollageMaster 
 where Id between 8 AND 10;


 create table UpSport(
    Id int primary key identity(1,1) not null,
    Name nvarchar(50) not null,
    SportsName nvarchar(50) not null
);

 create table PunjabSport(
    Id int primary key identity(1,1) not null,
    Name nvarchar(50) not null,
    SportsName nvarchar(50) not null
);


insert UpSport(Name, SportsName)
values('Mari','cricket'),
('Mr.A','football'),
('Mr.B','cricket')

insert PunjabSport(Name, SportsName)
values('Mari','cricket'),
('Mr.Y','cricket'),
('Mr.Z','BasketBall')

select * from UpSport
union 
select * from PunjabSport;


