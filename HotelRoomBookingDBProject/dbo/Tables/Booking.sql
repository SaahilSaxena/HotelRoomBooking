CREATE TABLE [dbo].[Booking] (
    [BookingId]   INT   IDENTITY (700, 1) NOT NULL,
    [CustomerId]  INT   NULL,
    [Checkin]     DATE  NOT NULL,
    [Checkout]    DATE  NOT NULL,
    [HotelId]     INT   NULL,
    [TotalAmount] MONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([BookingId] ASC),
    CONSTRAINT [Bookingfk] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    CONSTRAINT [Bookingfk1] FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotel] ([HotelId])
);

