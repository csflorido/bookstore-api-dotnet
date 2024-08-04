CREATE TABLE [dbo].[Publisher] (
    [PublisherId]          BIGINT           IDENTITY (1, 1) NOT NULL,
    [PublisherGuidKey]     UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PublisherName]        NVARCHAR (128)   NOT NULL,
    [CreatedTimestamp]     DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [LastUpdatedTimestamp] DATETIME         NULL
);
GO

ALTER TABLE [dbo].[Publisher]
    ADD CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED ([PublisherId] ASC);
GO

ALTER TABLE [dbo].[Publisher]
    ADD CONSTRAINT [UQ_PublisherGuidKey] UNIQUE NONCLUSTERED ([PublisherGuidKey] ASC);
GO

