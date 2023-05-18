using System;
using System.Collections.Generic;

namespace VideoGamesManager.DataAccess.EfModels;

public partial class Videogame
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int MinAge { get; set; }

    public string Description { get; set; } = null!;

    public int Owner { get; set; }

    public int Stock { get; set; }

    public int Price { get; set; }

    public virtual User OwnerNavigation { get; set; } = null!;
}
