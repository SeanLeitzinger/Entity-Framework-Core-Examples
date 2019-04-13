CREATE TABLE [dbo].[EmployeeDocument]
(
	[EmployeeId] INT NOT NULL,
	[FileDescriptionId] INT NOT NULL, 
	CONSTRAINT [FK_EmployeeDocument_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id]), 
	CONSTRAINT [FK_EmployeeDocument_FileDescription_FileDescriptionId] FOREIGN KEY ([FileDescriptionId]) REFERENCES [FileDescription]([Id]), 
	CONSTRAINT [PK_EmployeeDocument] PRIMARY KEY ([EmployeeId], [FileDescriptionId])
)
