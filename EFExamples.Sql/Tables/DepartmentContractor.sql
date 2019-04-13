CREATE TABLE [dbo].[DepartmentContractor] (
    [ContractorId] INT NOT NULL,
    [DepartmentId] INT NOT NULL,
    CONSTRAINT [PK_DepartmentContractor] PRIMARY KEY CLUSTERED ([ContractorId] ASC, [DepartmentId] ASC),
    CONSTRAINT [FK_DepartmentContractor_Contractor_ContractorId] FOREIGN KEY ([ContractorId]) REFERENCES [dbo].[Contractor] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DepartmentContractor_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentContractor_DepartmentId]
    ON [dbo].[DepartmentContractor]([DepartmentId] ASC);

