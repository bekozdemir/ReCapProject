CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT        NOT NULL IDENTITY,
    [BrandName] NCHAR (10) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

