CREATE TABLE [dbo].[Book] (
    [BookId]               BIGINT           IDENTITY (1, 1) NOT NULL,
    [BookGuidKey]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PublisherId]          BIGINT           NOT NULL,
    [Title]                NVARCHAR (128)   NOT NULL,
    [Isbn10]               VARCHAR (13)     NULL,
    [Isbn13]               VARCHAR (17)     NULL,
    [NumberOfPages]        SMALLINT         NULL,
    [WeightInKilos]        DECIMAL (6, 2)   NULL,
    [Price]                DECIMAL (8, 2)   NULL,
    [CreatedTimestamp]     DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [LastUpdatedTimestamp] DATETIME         NULL
);
GO

ALTER TABLE [dbo].[Book]
    ADD CONSTRAINT [FK_BookPublisher] FOREIGN KEY ([PublisherId]) REFERENCES [dbo].[Publisher] ([PublisherId]);
GO

ALTER TABLE [dbo].[Book]
    ADD CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

ALTER TABLE [dbo].[Book]
    ADD CONSTRAINT [UQ_BookGuidKey] UNIQUE NONCLUSTERED ([BookGuidKey] ASC);
GO

