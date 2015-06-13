CREATE TABLE [dbo].[BlogSet] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    [Url]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

