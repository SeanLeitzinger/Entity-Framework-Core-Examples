CREATE TABLE [dbo].[Employee] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [DateCreated]   DATETIME2 (2)    DEFAULT (sysdatetime()) NOT NULL,
    [DateUpdated]   DATETIME2 (2)    NULL,
    [CompanyId]     INT              NOT NULL,
    [DepartmentId]  INT              NOT NULL,
    [EmployeeId]    UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [StreetAddress] NVARCHAR (600)   DEFAULT (N'') NULL,
    [City]          NVARCHAR (150)   DEFAULT (N'') NULL,
    [State]         NVARCHAR (60)    DEFAULT (N'') NULL,
    [ZipCode]       NVARCHAR (12)    DEFAULT (N'') NULL,
    [DateOfBirth]   DATETIME2 (7)    NOT NULL,
    [FirstName]     NVARCHAR (300)   DEFAULT (N'') NULL,
    [LastName]      NVARCHAR (300)   DEFAULT (N'') NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_CompanyId]
    ON [dbo].[Employee]([CompanyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_DepartmentId]
    ON [dbo].[Employee]([DepartmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_EmployeeId]
    ON [dbo].[Employee]([EmployeeId] ASC);

