CREATE TABLE [dbo].[Company] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DateCreated] DATETIME2 (2)  DEFAULT (sysdatetime()) NOT NULL,
    [DateUpdated] DATETIME2 (2)  NULL,
    [Name]        NVARCHAR (300) DEFAULT (N'') NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);

