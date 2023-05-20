using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.Controllers;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Dbo;

[Authorize(Policy="NonAdminOnly")]
public class StockController : BaseController
{
    public StockController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
    {
    }

    // /Purchase/Buy
    public IActionResult Refill()
    {
        var availableGames = GetAvailableGames();

        return View(availableGames);
    }

    // POST: /Purchase/Confirm
    [HttpPost]
    public IActionResult Confirm(string gameId)
    {
        return View();
    }

    private List<VideoGame> GetAvailableGames()
    {
        return new List<VideoGame>()
        {
            new VideoGame() { Name="Black Ops 3", Description="Superb game", CategoryId=1, Min_age=18, Stock=12, Price=50},
            new VideoGame() { Name="Battlefield V", Description="Magnificent", CategoryId=2, Min_age=16, Stock=10, Price=40 },
            new VideoGame() { Name="Minecraft", Description="Cubes", CategoryId=3, Min_age=2, Stock=123, Price=10},
            new VideoGame() { Name="The Witcher", Description="Witches", CategoryId=4, Min_age=3, Stock=9, Price=200},
            new VideoGame() { Name="Cyberpunk", Description="Future", CategoryId=5, Min_age=7, Stock=40, Price=70},
            new VideoGame() { Name = "Red Dead Redemption 2", Description = "Wild West adventure", CategoryId=6, Min_age = 18, Stock = 15, Price = 60 },
            new VideoGame() { Name = "FIFA 22", Description = "Football simulation", CategoryId=7, Min_age = 3, Stock = 20, Price = 55 },
            new VideoGame() { Name = "Assassin's Creed Valhalla", Description = "Viking era stealth-action", CategoryId=8, Min_age = 16, Stock = 8, Price = 45 },
            new VideoGame() { Name = "Super Mario Odyssey", Description = "Nintendo platformer", CategoryId=9, Min_age = 6, Stock = 25, Price = 50 },
            new VideoGame() { Name = "Call of Duty: Warzone", Description = "Battle Royale shooter", CategoryId=10, Min_age = 18, Stock = 30, Price = 0 }
        };
    }
}
