using System;
using System.Collections.Generic;

namespace VideoGamesManager.DataAccess.EfModels;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Videogame> Videogames { get; set; } = new List<Videogame>();
}
