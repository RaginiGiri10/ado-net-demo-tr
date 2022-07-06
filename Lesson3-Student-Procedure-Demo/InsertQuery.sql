
create procedure spInsertStudentRecord
@name varchar(30),
@email varchar(30),
@mobile varchar(20)
as
Begin

Insert into Student values(@name,@email,@mobile)

End

go

select * from Student

go

exec spInsertStudentRecord 'Aaquib','Aaquib@test.com','8853456789'
go

select * from Student