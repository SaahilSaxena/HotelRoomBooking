CREATE proc [dbo].[GetAvailableRooms1] @checkin datetime,@checkout datetime,@HotelId int,@ac char(1),@wifi char(1) as

select h.HotelId,r.RoomId,h.HotelName ,h.City,h.HotelContact,r.RoomPrice, b.checkin, b.checkout from Hotel h join HotelRoom r on
h.HotelId=r.HotelId join Booking b on h.HotelId= b.HotelId where h.HotelId=@HotelId 
and r.Air_Conditioner=@ac and r.Wi_fi=@wifi
and r.RoomId in
(
    select RoomId from HotelRoom where HotelId=@HotelId  except
    (
	select  b.RoomId from Booking a join BookingDetails b on a.BookingId=b.BookingId where b.HotelId=@HotelId
and ((@checkin <= a.checkin  and (@checkout between a.checkin and a.checkout)) or
    (( @checkin between a.checkin and a.checkout) and (@checkout >= a.checkout))) or
    (( @checkin < a.checkin) and (@checkout > a.checkout)) or
    ((@checkin between a.checkin and a.checkout) and (@checkout between a.checkin and a.checkout))
  ) 
 )
