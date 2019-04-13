CREATE TABLE [dbo].[Department] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DateCreated] DATETIME2 (2)  DEFAULT (sysdatetime()) NOT NULL,
    [DateUpdated] DATETIME2 (2)  NULL,
    [CompanyId]   INT            NOT NULL,
    [Name]        NVARCHAR (300) DEFAULT (N'') NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Department_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Department_CompanyId]
    ON [dbo].[Department]([CompanyId] ASC);

