using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VideoGamesManager.DataAccess.EfModels;

public partial class User : IdentityUser<int>
{
    public virtual ICollection<Videogame> Videogames { get; set; } = new List<Videogame>();
}
