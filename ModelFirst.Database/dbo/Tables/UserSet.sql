CREATE TABLE [dbo].[UserSet] (
    [UserName]    NVARCHAR (50)  NOT NULL,
    [DisplayName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_UserSet] PRIMARY KEY CLUSTERED ([UserName] ASC)
);

