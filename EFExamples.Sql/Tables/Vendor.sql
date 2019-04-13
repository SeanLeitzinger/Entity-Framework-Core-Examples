CREATE TABLE [dbo].[Vendor] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DateCreated] DATETIME2 (2)  DEFAULT (sysdatetime()) NOT NULL,
    [DateUpdated] DATETIME2 (2)  NULL,
    [Name]        NVARCHAR (300) DEFAULT (N'') NULL,
    CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

