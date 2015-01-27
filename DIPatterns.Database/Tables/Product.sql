CREATE TABLE [dbo].[Product]
(
    [Id]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [ProductName]    VARCHAR (200) NULL,
    [Brand]          VARCHAR (100) NULL,
    [Price]          MONEY         NOT NULL,
    [ListPrice] MONEY NOT NULL DEFAULT 0, 
    [Site]           VARCHAR (100) NOT NULL,
    [ProductUrl]        VARCHAR (300) NOT NULL,
    [PriceDate]      DATETIME2 (7) CONSTRAINT [DF_Product_PriceDate] DEFAULT (getdate()) NOT NULL,
    [ProductCode] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE UNIQUE INDEX [UX_Product_ProductUrl] ON [dbo].[Product] ([ProductUrl])
