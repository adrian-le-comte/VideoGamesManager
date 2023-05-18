using System;
using System.Collections.Generic;

namespace VideoGamesManager.DataAccess.EfModels;

public partial class Videogame
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Category { get; set; } = null!;

    public int? MinAge { get; set; }

    public string? Description { get; set; }

    public int? Owner { get; set; }

    public virtual User? OwnerNavigation { get; set; }
}
