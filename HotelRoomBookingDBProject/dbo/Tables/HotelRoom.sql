CREATE TABLE [dbo].[HotelRoom] (
    [RoomId]          INT      IDENTITY (200, 1) NOT NULL,
    [Air_Conditioner] CHAR (1) NOT NULL,
    [Wi_fi]           CHAR (1) NOT NULL,
    [RoomPrice]       MONEY    NULL,
    [HotelId]         INT      NULL,
    PRIMARY KEY CLUSTERED ([RoomId] ASC),
    CONSTRAINT [HotelRoomfk] FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotel] ([HotelId])
);

