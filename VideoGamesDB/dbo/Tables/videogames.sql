CREATE TABLE [dbo].[videogames] (
    [id]          INT            NOT NULL,
    [name]        NVARCHAR (MAX) NOT NULL,
    [min_age]     INT            NOT NULL,
    [description] NVARCHAR (MAX) NOT NULL,
    [stock]       INT            NOT NULL,
    [price]       INT            NOT NULL,
    [owner_id]    INT            NOT NULL,
    [studio_id]   INT            NOT NULL,
    [category_id] INT            NOT NULL,
    CONSTRAINT [PK__videogam__3213E83F2A4215B5] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__videogame__categ__6A30C649] FOREIGN KEY ([category_id]) REFERENCES [dbo].[categories] ([id]),
    CONSTRAINT [FK__videogame__owner__6B24EA82] FOREIGN KEY ([owner_id]) REFERENCES [dbo].[users] ([id]),
    CONSTRAINT [FK__videogame__studi__693CA210] FOREIGN KEY ([studio_id]) REFERENCES [dbo].[studios] ([id])
);







