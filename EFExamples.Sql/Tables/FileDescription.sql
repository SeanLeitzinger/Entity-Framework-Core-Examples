CREATE TABLE [dbo].[FileDescription]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[DocumentTypeId] INT NOT NULL,
	[ContentType] VARCHAR(150) NOT NULL DEFAULT(''),
	[Description] VARCHAR(400) NOT NULL DEFAULT(''),
	[FileName] VARCHAR(400) NOT NULL DEFAULT(''),
	[DateCreated] DATETIME2 (2)  DEFAULT (sysdatetime()) NOT NULL,
	[DateUpdated] DATETIME2 (2)  NULL
	CONSTRAINT [FK_FileDescription_DocumentType_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentType]([Id])
)
