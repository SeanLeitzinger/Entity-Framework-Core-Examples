CREATE TABLE [dbo].[Contractor] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [DateCreated]   DATETIME2 (2)  DEFAULT (sysdatetime()) NOT NULL,
    [DateUpdated]   DATETIME2 (2)  NULL,
    [VendorId]      INT            NOT NULL,
    [StreetAddress] NVARCHAR (600) DEFAULT (N'') NULL,
    [City]          NVARCHAR (150) DEFAULT (N'') NULL,
    [State]         NVARCHAR (60)  DEFAULT (N'') NULL,
    [ZipCode]       NVARCHAR (12)  DEFAULT (N'') NULL,
    [DateOfBirth]   DATETIME2 (7)  NOT NULL,
    [FirstName]     NVARCHAR (300) DEFAULT (N'') NULL,
    [LastName]      NVARCHAR (300) DEFAULT (N'') NULL,
    CONSTRAINT [PK_Contractor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contractor_Vendor_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Contractor_VendorId]
    ON [dbo].[Contractor]([VendorId] ASC);

