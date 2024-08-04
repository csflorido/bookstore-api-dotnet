CREATE TABLE [dbo].[BookAuthor] (
    [BookAuthorId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [BookId]              BIGINT         NOT NULL,
    [AuthorId]            BIGINT         NOT NULL,
    [DisplayOrder]        TINYINT        NULL,
    [AboutAuthor]         NVARCHAR (MAX) NULL,
    [LanguageISO6392Code] VARCHAR (4)    NULL
);
GO

ALTER TABLE [dbo].[BookAuthor]
    ADD CONSTRAINT [FK_BookAuthor_Book] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([BookId]) ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[BookAuthor]
    ADD CONSTRAINT [FK_BookAuthor_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Author] ([AuthorId]) ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[BookAuthor]
    ADD CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED ([BookAuthorId] ASC);
GO

ALTER TABLE [dbo].[BookAuthor]
    ADD CONSTRAINT [UQ_BookAuthor] UNIQUE NONCLUSTERED ([BookId] ASC, [AuthorId] ASC);
GO

