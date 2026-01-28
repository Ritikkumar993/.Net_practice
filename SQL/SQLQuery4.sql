-- write a sp to insert the new hostel student if the hostel student count is less than 5

alter proc HostelChecktoInsert
	
	@RoomNo int,
	@StudentId int
as 
begin
	declare @scount int
	select @scount =  Count(*) from dbo.CollageMaster c inner join dbo.BHostel bh on c.Id=bh.StudentId

	if @scount<5
	begin
		insert INTO BHostel(RoomNo,StudentId)
		values(@RoomNo, @StudentId)
	end
end;


EXEC [dbo].[HostelChecktoInsert] 103, 10

select * from dbo.CollageMaster c inner join dbo.BHostel bh on c.Id=bh.StudentId;


ALTER TABLE CollageMaster ADD CONSTRAINT M1CHECK CHECK(M1>=0 AND M1<=100);
ALTER TABLE CollageMaster ADD CONSTRAINT GenderCheck CHECK(Gender='M' or Gender='F');
ALTER TABLE CollageMaster ADD CONSTRAINT PhoneNoCHECK CHECK(Len(PhoneNo)=10 and PhoneNo NOT LIKE '%[^0-9]%');

ALTER TABLE CollageMaster ADD CONSTRAINT M2CHECK CHECK(M2>=0 AND M2<=100);
ALTER TABLE CollageMaster ADD CONSTRAINT M3CHECK CHECK(M3>=0 AND M3<=100);

INSERT INTO  CollageMaster(Name,M1,M2,M3,Gender,PhoneNo,Department) 
	values('Raman',90,95,70,'M','9876543210','ME' )


select DATEDIFF(day,'2002-11-06', GETDATE()) as BirthDiff;
select DATEDIFF(YEAR,'2002-11-06', GETDATE()) as BirthDiff;
select DATEDIFF(MONTH,'2002-11-06', GETDATE()) as BirthDiff;

select *  from CollageMaster c where month(DOB) = 8;

create proc GETSTUDENTBYMONTH
	@Month int
as
begin
	select *  from CollageMaster c where month(DOB) = @Month
end;

exec dbo.GETSTUDENTBYMONTH 1




