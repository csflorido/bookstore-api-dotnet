CREATE TABLE [dbo].[Author] (
    [AuthorId]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [AuthorGuidKey]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FirstName]            NVARCHAR (128)   NULL,
    [LastName]             NVARCHAR (128)   NULL,
    [DisplayName]          NVARCHAR (256)   NULL,
    [CreatedTimestamp]     DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [LastUpdatedTimestamp] DATETIME         NULL
);
GO

ALTER TABLE [dbo].[Author]
    ADD CONSTRAINT [UQ_AuthorGuidKey] UNIQUE NONCLUSTERED ([AuthorGuidKey] ASC);
GO

ALTER TABLE [dbo].[Author]
    ADD CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([AuthorId] ASC);
GO

