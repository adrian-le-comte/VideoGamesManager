CREATE TABLE [dbo].[users] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [username]   NVARCHAR (255) NULL,
    [password]   NVARCHAR (255) NULL,
    [role]       NVARCHAR (255) NULL,
    [created_at] ROWVERSION     NOT NULL,
    CONSTRAINT [PK__users__3213E83F8498177C] PRIMARY KEY CLUSTERED ([id] ASC)
);

