CREATE TABLE [dbo].[Hotel] (
    [HotelId]      INT           IDENTITY (500, 1) NOT NULL,
    [HotelName]    VARCHAR (30)  NOT NULL,
    [Address]      VARCHAR (50)  NOT NULL,
    [City]         VARCHAR (20)  NOT NULL,
    [HotelContact] VARCHAR (15)  NOT NULL,
    [HotelImage]   VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([HotelId] ASC)
);

