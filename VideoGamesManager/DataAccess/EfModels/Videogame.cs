using System;
using System.Collections.Generic;

namespace VideoGamesManager.DataAccess.EfModels;

public partial class Videogame
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MinAge { get; set; }

    public string Description { get; set; } = null!;

    public int Stock { get; set; }

    public int Price { get; set; }

    public int OwnerId { get; set; }

    public int StudioId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;

    public virtual Studio Studio { get; set; } = null!;
}
