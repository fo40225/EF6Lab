CREATE TABLE [dbo].[PostSet] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [BlogId]  INT            NOT NULL,
    CONSTRAINT [PK_PostSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogPost] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[BlogSet] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_BlogPost]
    ON [dbo].[PostSet]([BlogId] ASC);

