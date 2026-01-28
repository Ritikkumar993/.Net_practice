create proc ups_getstudentName
as 
begin
select * from CollageMaster
end

Exec ups_getstudentName


---------------------------------


create PROCEDURE dbo.upsgetstudentbyDept
	@dept nvarchar(10),
	@StudentCount INT output
as
begin
	select @StudentCount = count(*) from [dbo].[CollageMaster] where [Department] =@dept
end;

Declare @scount int

Exec dbo.upsgetstudentbyDept
@dept ='cse',
@StudentCount = @scount OUTPUT

select @scount

alter proc GetStudentName
as
begin
	select * from dbo.CollageMaster c left join dbo.BHostel bh on c.Id=bh.StudentId left join dbo.GHostel gh on c.id=gh.StudentId
end;

Exec [dbo].[GetStudentName]

alter proc GetStudentNameInPerticularRoom
as
begin
	select * from dbo.CollageMaster c left join dbo.BHostel bh on c.Id=bh.StudentId left join dbo.GHostel gh on c.id=gh.StudentId where bh.RoomNo=101 or gh.RoomNo=101;
end;


EXEC [dbo].[GetStudentNameInPerticularRoom]






