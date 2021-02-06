CREATE TABLE [dbo].[Cars] (
    [CarId]          INT        NOT NULL,
    [ModelYear]   INT        NULL,
    [DailyPrice]  INT        NULL,
    [Description] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC)
);

