
create proc GetAvailableRooms @checkin datetime,@checkout datetime,@HotelId int as

select h.HotelId,r.RoomId,h.HotelName ,h.City,h.HotelContact from Hotel h join HotelRoom r on
h.HotelId=r.HotelId where h.HotelId=@HotelId and r.RoomId in
(
    select RoomId from HotelRoom where HotelId=@HotelId  except
    (
	select  b.RoomId from Booking a join BookingDetails b on a.BookingId=b.BookingId where b.HotelId=@HotelId
and ((@checkin <= a.Checkin  and (@checkout between a.Checkin and a.Checkout)) or
    (( @checkin between a.Checkin and a.Checkout) and (@checkout >= a.Checkout))) or
    (( @checkin < a.Checkin) and (@checkout > a.Checkout)) or
    ((@checkin between Checkin and checkout) and (@checkout between checkin and Checkout))
  ) 
)


----------------------------------------------------------------------------------------------------------------------