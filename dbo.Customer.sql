CREATE TABLE [dbo].[Customers] (
    [UserId]      INT        IDENTITY (1, 1) NOT NULL,
    [CompanyName] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

