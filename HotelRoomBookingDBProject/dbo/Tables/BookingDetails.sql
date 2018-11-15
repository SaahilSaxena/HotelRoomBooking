CREATE TABLE [dbo].[BookingDetails] (
    [BookingId] INT   NOT NULL,
    [HotelId]   INT   NULL,
    [RoomId]    INT   NOT NULL,
    [Days]      INT   NOT NULL,
    [RoomPrice] MONEY NULL,
    CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED ([BookingId] ASC, [RoomId] ASC),
    CONSTRAINT [BookingDetailsfk] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Booking] ([BookingId]),
    CONSTRAINT [BookingDetailsfk1] FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotel] ([HotelId]),
    CONSTRAINT [BookingDetailsfk2] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[HotelRoom] ([RoomId])
);

