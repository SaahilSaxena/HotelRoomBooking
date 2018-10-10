
--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Customer~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
create table Customer
(
CustomerId int identity(100,1) primary key,
CustomerName varchar(20) not null,
CustomerContact varchar(10) not null,
Email varchar(30) not null,
City varchar(20) not null,
[Password] varchar(20) not null
)
drop table Customer
select * from Customer

--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Hotel ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
create table Hotel
(
HotelId int identity(500,1) primary key,
HotelName varchar(30) not null,
[Address] varchar(50) not null,
City varchar(20) not null,  
HotelContact varchar(15) not null
)
drop table Hotel
select * from Hotel

--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Hotel Room~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
create table HotelRoom
(
RoomId int identity(200,1) primary key,
HotelId int constraint HotelRoomfk foreign key references Hotel(HotelId),     
Air_Conditioner char(1) not null,
Wi_fi char(1) not null,
RoomPrice money
)
drop table HotelRoom
select * from HotelRoom

--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Booking~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
create table Booking
(
BookingId int identity(700,1) primary key,
CustomerId int constraint Bookingfk foreign key references Customer(CustomerId),   
Checkin date not null,
Checkout date not null,
HotelId int constraint Bookingfk1 foreign key references Hotel(HotelId),                  
TotalAmount money not null
)
drop table Booking
select * from Booking

--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Booking Details~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
create table BookingDetails
(
BookingId int constraint BookingDetailsfk foreign key references Booking(BookingId),            
HotelId int constraint BookingDetailsfk1 foreign key references Hotel(HotelId),          
RoomId int constraint  BookingDetailsfk2 foreign key references HotelRoom(RoomId),            
Days int not null,
RoomPrice money
)
drop table BookingDetails
select * from BookingDetails

--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Payment~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
create table Payment(
BookingId int constraint Paymentfk foreign key references Booking(BookingId),     
CustomerId int constraint Paymentfk1 foreign key references Customer(CustomerId),          
PaymentType varchar(20),
TotalAmount money,
Date date not null,
PaymentInvoiceNo varchar(10) not null
)
drop table Payment
select * from Payment 


