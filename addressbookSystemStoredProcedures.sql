create procedure spObtainingData
as
begin
select * from Address_Book; 
end;

create procedure spAddingData
(@First_Name varchar(30),@Last_Name varchar(30),@Address varchar(50),@City varchar(50),
@State varchar(50),@Zip int ,@Mobile_Number varchar(10),@Email_Id varchar(40),
@Address_Book_Name varchar(20),@Type varchar(20))
as
begin
insert into Address_Book values
(@First_Name,@Last_Name,@Address,@City,@State,@Zip,@Mobile_Number,@Email_Id,
@Address_Book_Name ,@Type )
end;

create procedure spUpdatingPersonData
(@First_Name varchar(30),@Address varchar(50))
as
begin
Update Address_Book set Address=@Address where First_Name=@First_Name ;
end;
select * from Person_And_AddressBook
delete from Person_And_AddressBook where Person_id=12;

create procedure spDeletingPersonData
(@First_Name varchar(30))
as
begin 
delete from Address_Book where First_Name=@First_Name;
end;

create procedure spRetrieveDataByCityOrState
(@City varchar(50),@State varchar(50))
as 
begin
Select * from Address_Book where city = @City and State= @State;
end;

create procedure spRetrieveDataUsingCityOrState
(@City varchar(50),@State varchar(50),@First_Name varchar(30),@Last_Name varchar(30))
as 
begin
Select First_Name,Last_Name,City,State from Address_Book where city = @City and State=@State ;
end;

create procedure spCountByCityOrState
(@City varchar(50),@State varchar(50))
as
begin
Select Count(@State) as city_count from Address_Book
where City='@City' and State='@State';
end;
Select Count(State) as state_count from Address_Book
where City='Mumbai' and State='Maharashtra';

create procedure spSortByName
(@First_Name varchar(30),@Last_Name varchar(30),@City varchar(50))
as
begin
select First_Name,Last_Name,City from Address_Book where City = @City order by First_Name;
end;

create procedure spAddressBookTypeInfo
(@person_type varchar(20) ,
@address_book_name varchar(50))
as
begin
Insert into Address_Book_Type
values(@person_type,@address_book_name);
end;

create procedure spPersonDepartmentInfo
(@Person_Id int,@Book_Id int)
as
begin
Insert Into Person_And_AddressBook
values(@Person_Id,@Book_Id);
end;

create procedure spCountByType
as
begin
Select Count(Book_Id) as Contacts,Book_Id from Person_And_AddressBook
Group by Book_Id;
end