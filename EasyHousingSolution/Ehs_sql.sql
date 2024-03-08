
Create database EHSDB;

use EHSDB


Create table EHS_Users
(
	UserName varchar(25) primary key,
	Password varchar(25) not null,
	UserType varchar(15)
);

Create table EHS_Seller
(
	SellerId int identity(1,1) primary key,
	UserName varchar(25) not null,
	FirstName varchar(25) not null,
	LastName varchar(25),
	DateofBirth date not null,
	PhoneNo varchar(10) not null,
	Address varchar(250) not null,
	StateId int not null FOREIGN KEY REFERENCES EHS_State(StateId),
	CityId int  not null FOREIGN KEY REFERENCES EHS_City(CityId),
	EmailId varchar(50) not null
);


Create table EHS_State
(
	StateId int identity(1,1) primary key,
	StateName varchar(30)
);

Create table EHS_City
(
	CityId int identity(1,1) primary key,
	CityName varchar(50) not null,
	StateId int not null FOREIGN KEY REFERENCES EHS_State(StateId)
);



Create table EHS_Buyer
(
	BuyerId int identity(1,1) primary key,
	FirstName varchar(25) not null,
	LastName varchar(25),
	DateOfBirth date not null,
	PhoneNo varchar(10) not null,
	EmailId varchar(50) not null
);


Create table EHS_Property
(
	PropertyId int identity(1,1) primary key,
	PropertyName varchar(50) not null,
	PropertyType varchar(15) not null,
	PropertyOption varchar(10) not null,
	Description varchar(250),
	Address varchar(250) not null,
	PriceRange money not null,
	InitialDeposit money not null,
	LandMark varchar(25) not null,
	IsActive bit not null,
	SellerId int not null FOREIGN KEY REFERENCES EHS_Seller(SellerId)
);


Create table EHS_Images
(
	ImageId int identity(1,1) primary key,
	PropertyId int not null FOREIGN KEY REFERENCES EHS_Property(PropertyId),
	Image image not null
);

Create table EHS_Cart
(
	CartId int identity(1,1) primary key,
	BuyerId int not null Foreign key REFERENCES EHS_Buyer(BuyerId),
	PropertyId int not null FOREIGN KEY REFERENCES EHS_Property(PropertyId)
);

select * from EHS_Users;
select * from EHS_State;
select * from EHS_Seller;
select * from EHS_Property;
select * from EHS_Images;
select * from EHS_City;
select * from EHS_Cart;
select * from EHS_Buyer;





 insert into EHS_State values('Karnataka');
 insert into EHS_State values('Andra Pradesh');
 insert into EHS_State values('Bihar');
 insert into EHS_State values('Kerala');
 insert into EHS_State values('Maharashtra');
 insert into EHS_State values('Tamil Nadu');
 insert into EHS_State values('Telangana');

 select*from EHS_State
 

 insert into EHS_City values('Bangalore',1);
 insert into EHS_City values('Hyderabad',2);
 insert into EHS_City values('Patna',3);
 insert into EHS_City values('Trivandrum',4);
 insert into EHS_City values('Mumbai',5);
 insert into EHS_City values('Chennai',6);
 insert into EHS_City values('Hyderabad',7);
 
 select*from EHS_City

 
insert into EHS_Buyer values( 'alok', 'sharma','1992-01-22',9867543065,'alok@gmail.com');

insert into EHS_Buyer values( 'elok', 'NULL','1900-10-06',9867543065,'elok@gmail.com');

insert into EHS_Buyer values('aliya', 'savitha','1900-10-01',9867543065,'aliya@gmail.com');

insert into EHS_Buyer values( 'amulu', 'shree','1900-01-12',9867543065,'amulu@gmail.com');

insert into EHS_Buyer values( 'arya', 'shilpa','1890-12-12',9867543065,'arya@gmail.com');

insert into EHS_Buyer values( 'kaviya', 'sharma','1990-10-01',9867543065,'kaviya@gmail.com');

insert into EHS_Buyer values( 'arish', 'NULL','2000-12-12',9867543065,'arish@gmail.com');



INSERT INTO EHS_Seller VALUES('AMITHANAND','AMITH','ANAD','2012-01-22',8086555847,'KERALA',1,1,'AMITH@GMAIL.COM');
INSERT INTO EHS_Seller VALUES('KUMARALOK','ALOK','KUMAR','2017-02-12',8086555777,'KARNADAKA',2,2,'ALOKKUMAR@GMAIL.COM');
INSERT INTO EHS_Seller VALUES('SREEANJU','ANJU','SREE','1990-03-23',8086555888,'TAMIL NADU',3,3,'ANJUSREE@GMAIL.COM');
INSERT INTO EHS_Seller VALUES('RIYAANAND','RIYA','ANAD','1999-05-19',8086558797,'KERALA',4,4,'RIYA@GMAIL.COM');
INSERT INTO EHS_Seller VALUES('AYSHAASHOK','AYSHA','ASHOK','1998-03-20',8086555846,'KERALA',5,5,'AYSHAASHOK@GMAIL.COM');
INSERT INTO EHS_Seller VALUES('MANJIMA','MANJIMA','MAHESH','1969-01-25',8086444481,'DELHI',6,6,'MANJIMAMAHESH.COM');
INSERT INTO EHS_Seller VALUES('ANJALI','ANAGA','ANJALI','2000-04-22',8086555123,'PUNE',7,7,'ANJALI@GMAIL.COM');


insert into EHS_Property VALUES('Jaswanth Villa','Single House','Rent','3 BHK,2800 sft,Peaceful environment','#06 Jaswanth Villa,Nizampet,Hyderabad,Telangana',4000-5000,2500,'Nizampet',1,1);
insert into EHS_Property VALUES('HHH APARTMENTS','Flat','Rent','2 BHK,1500 sft,Community','#301,Hemavathi badavane,Mysore,Karnataka',2000-3000,1500,'Hemavathi badvane',1,2);
insert into EHS_Property VALUES('Sri Constructions','Vacant Land','Lease','6000 sft,Land for lease','#321,Townhall,hundred road street,Mumbai,Maharastra',300-450,500,'hundred road street',1,3);
insert into EHS_Property VALUES('VVV Residency','Group House','sale','5900 sft,Gound Floor in Group House is for sale','#02  ,skyline villa,Kozhikode, Kerala',300-450,500,'Kozhikode',1,4);
insert into EHS_Property VALUES('Friends Cafe','Shop/Cafe','Rent','1260 sft,Cafe is for rent at crowded people area','#118,Friends Cafe,Madrasroadstreet,Kazibad,Pune',300-450,500,'Madrasroadstreet',1,5);
insert into EHS_Property VALUES('Farmers Association','Agri Land','Sale','1.5 Acre,2 Crops per Year, Good Soil','#900,mountain hill,kodaikanal,Kashmircity,Delhi',8000000-8600000,200000,'Kodaikanal',1,6);
insert into EHS_Property VALUES('STAY HOME','P.G Hostel','Rent','3 Sharing,Including Food and Lockers','#876,goodlightstreet,mindtreeroad,Gujarat',8000000-8600000,200000,'GoodlightStreet',1,7);

select * from EHS_Property;

insert into EHS_Users values ('Rajakanth','raja@123','Seller');
insert into EHS_Users values ('Delip','delip@147','Buyer');
insert into EHS_Users values ('Manjunath','manju@258','Seller') 
insert into EHS_Users values ('Raguram','raguram@369','Buyer');
insert into EHS_Users values ('Sumithra','sumi@789','Seller');
insert into EHS_Users values ('Ramya','ram@456','Buyer');
insert into EHS_Users values ('Pavithra','pavi@321','Seller');
insert into EHS_Users values ('Mohan','mohan@654','Buyer');

select * from EHS_Users;
----creating stored procedures
--CREATE PROCEDURE SelectAll_sellers 
--as 
--select * from EHS_Seller 
--go;

--EXEC SelectAll_sellers ;

--CREATE PROCEDURE SelectAll_Buyers 
--as 
--select * from EHS_Buyer 
--go;

--EXEC SelectAll_Buyers;

--CREATE PROCEDURE SelectAll_Properties
--as 
--select * from EHS_Property 
--go;

--EXEC SelectAll_Properties;

--CREATE PROCEDURE SelectAll_Cities 
--as 
--select * from EHS_City
--go;

--EXEC SelectAll_Cities ;

--CREATE PROCEDURE SelectAll_States 
--as 
--select * from EHS_State
--go;

--EXEC SelectAll_States ;

--CREATE PROCEDURE SelectAll_Users
--as 
--select * from EHS_Users 
--go;

--EXEC SelectAll_Users ;



--CREATE PROCEDURE SelectAll_Admins
--as
--select * from EHS_Admin
--go;

--exec SelectAll_Admins;







