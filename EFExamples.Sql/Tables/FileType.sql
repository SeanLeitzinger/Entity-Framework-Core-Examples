CREATE TABLE [dbo].[FileType]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[DateCreated]   DATETIME2 (2)    DEFAULT (sysdatetime()) NOT NULL,
	[DateUpdated]   DATETIME2 (2)    NULL,
	[Name] VARCHAR(300) NOT NULL
)
