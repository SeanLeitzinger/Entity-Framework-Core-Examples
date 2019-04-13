CREATE TABLE [dbo].[DocumentType]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] VARCHAR(300) NOT NULL DEFAULT (''),
	[DateCreated] DATETIME2 (2)  DEFAULT (sysdatetime()) NOT NULL,
	[DateUpdated] DATETIME2 (2)  NULL,
)
