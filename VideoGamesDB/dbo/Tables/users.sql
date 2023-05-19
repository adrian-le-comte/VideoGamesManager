CREATE TABLE [dbo].[users] (
    [id]       INT            NOT NULL,
    [username] NVARCHAR (255) NOT NULL,
    [password] NVARCHAR (255) NOT NULL,
    [role]     NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK__users__3213E83F889E0DF5] PRIMARY KEY CLUSTERED ([id] ASC)
);





