using System;
using System.Collections.Generic;

namespace VideoGamesManager.DataAccess.EfModels;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual ICollection<Videogame> Videogames { get; set; } = new List<Videogame>();
}
