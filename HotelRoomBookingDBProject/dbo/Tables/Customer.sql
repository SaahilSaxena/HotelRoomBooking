CREATE TABLE [dbo].[Customer] (
    [CustomerId]      INT          IDENTITY (100, 1) NOT NULL,
    [CustomerName]    VARCHAR (20) NOT NULL,
    [CustomerContact] VARCHAR (10) NOT NULL,
    [Email]           VARCHAR (30) NOT NULL,
    [City]            VARCHAR (20) NOT NULL,
    [Password]        VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

