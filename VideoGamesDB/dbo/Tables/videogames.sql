CREATE TABLE [dbo].[videogames] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (255) NOT NULL,
    [category]    NVARCHAR (255) NOT NULL,
    [min_age]     INT            NOT NULL,
    [description] NVARCHAR (255) NOT NULL,
    [owner]       INT            NOT NULL,
    [stock]       INT            NOT NULL,
    [price]       INT            NOT NULL,
    CONSTRAINT [PK__videogam__3213E83FB236F142] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK__videogame__categ__3B75D760] CHECK ([category]='moba' OR [category]='fps' OR [category]='strategy' OR [category]='mmo' OR [category]='rpg'),
    CONSTRAINT [FK_videogames_users] FOREIGN KEY ([owner]) REFERENCES [dbo].[users] ([id])
);





