CREATE TABLE [dbo].[Payment] (
    [BookingId]        INT          NOT NULL,
    [CustomerId]       INT          NOT NULL,
    [HotelId]          INT          NOT NULL,
    [PaymentType]      VARCHAR (20) NULL,
    [TotalAmount]      MONEY        NULL,
    [Date]             DATE         NOT NULL,
    [PaymentInvoiceNo] INT          IDENTITY (4500, 1) NOT NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED ([PaymentInvoiceNo] ASC),
    CONSTRAINT [Paymentfk] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Booking] ([BookingId]),
    CONSTRAINT [Paymentfk1] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    CONSTRAINT [Paymentfk2] FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotel] ([HotelId])
);

