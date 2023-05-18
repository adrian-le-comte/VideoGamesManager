using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.Dbo;
public class PurchaseController : Controller
{
    // GET: /Purchase/Buy
    public IActionResult Buy()
    {
        // Implement the logic to retrieve the available video games from your stock
        // You can pass the list of available video games to the view
        var availableGames = GetAvailableGames();

        // Return the view along with the available games
        return View(availableGames);
    }

    // POST: /Purchase/Confirm
    [HttpPost]
    public IActionResult Confirm(string gameId)
    {
        // Implement the logic to handle the purchase confirmation
        // You can retrieve the selected game based on the gameId parameter

        // Process the purchase, update the stock, etc.

        // Return a view or redirect to a success page
        return View();
    }

    // Helper method to retrieve the available video games
    private List<VideoGame> GetAvailableGames()
    {
        // Implement the logic to fetch the available games from your stock
        // This can be from a database, API, or any other data source

        // Return a list of Game objects representing the available games
        return new List<VideoGame>()
        {
            new VideoGame() { Name="Black Ops 3", Description="Superb game", Category="fps", Min_age=18, Stock=12, Price=50},
            new VideoGame() { Name="Battlefield V", Description="Magnificent", Category="mmo", Min_age=16, Stock=10, Price=40 },
            new VideoGame() { Name="Minecraft", Description="Cubes", Category="cubes", Min_age=2, Stock=123, Price=10},
            new VideoGame() { Name="The Witcher", Description="Witches", Category="rpg", Min_age=3, Stock=9, Price=200},
            new VideoGame() { Name="Cyberpunk", Description="Future", Category="Futurisitc", Min_age=7, Stock=40, Price=70},
            new VideoGame() { Name = "Red Dead Redemption 2", Description = "Wild West adventure", Category = "action", Min_age = 18, Stock = 15, Price = 60 },
            new VideoGame() { Name = "FIFA 22", Description = "Football simulation", Category = "sports", Min_age = 3, Stock = 20, Price = 55 },
            new VideoGame() { Name = "Assassin's Creed Valhalla", Description = "Viking era stealth-action", Category = "adventure", Min_age = 16, Stock = 8, Price = 45 },
            new VideoGame() { Name = "Super Mario Odyssey", Description = "Nintendo platformer", Category = "platformer", Min_age = 6, Stock = 25, Price = 50 },
            new VideoGame() { Name = "Call of Duty: Warzone", Description = "Battle Royale shooter", Category = "fps", Min_age = 18, Stock = 30, Price = 0 }
        };
    }
}
