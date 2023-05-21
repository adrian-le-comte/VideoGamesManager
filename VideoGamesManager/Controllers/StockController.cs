using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.Controllers;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Dbo;
using VideoGamesManager.Models;

[Authorize(Policy="NonAdminOnly")]
public class StockController : BaseController
{
    public StockController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
    {
    }

    public IActionResult Refill()
    {
        var availableGames = _mapper.Map<List<VideoGamesViewModel>>(GetAvailableGames());
        
        return View(availableGames);
    }

    [HttpPost]
    public async Task<IActionResult> Confirm(int[] quantities, int[] gameIds)
    {
        for (int i = 0; i < quantities.Length; i++)
        {
            int quantity = quantities[i];
            int gameId = gameIds[i];
            if (quantity == 0)
                continue;
            var adminQuantityGame = _videoGamesRepository.GetVideoGamesByOwnerId(GetAdminUserId()).Where(x => x.Id == gameId).FirstOrDefault().Stock;
            if (adminQuantityGame < quantity)
            {
                Console.WriteLine("ERROROEWORREORWEORWOEROWEORWRWE " + gameId + " ");
                // Add error here;
                return RedirectToAction("Refill");
            }
            var adminGame = _videoGamesRepository.GetVideoGameById(gameId);
            adminGame.Stock -= quantity;
            await _videoGamesRepository.UpdateVideoGames(adminGame);

            var gameName = adminGame.Name;
            var userGame = _videoGamesRepository.GetVideoGamesByOwnerId(GetCurrentUserId()).Where(x => x.Name == gameName).FirstOrDefault();
            if (userGame == null)
            {
                VideoGame vgame = new VideoGame()
                {
                    Description = adminGame.Description,
                    Name = adminGame.Name,
                    CategoryId = adminGame.CategoryId,
                    Min_age = adminGame.Min_age,
                    OwnerId = GetCurrentUserId(),
                    Price = adminGame.Price,
                    Stock = quantity,
                    StudioId = adminGame.StudioId
                };
                vgame.Stock = quantity;
                await _videoGamesRepository.AddVideoGames(vgame);
            }
            else
            {
                userGame.Stock += quantity;
                await _videoGamesRepository.UpdateVideoGames(userGame);
            }
        }

        return RedirectToAction("Refill");
    }

    private List<VideoGame> GetAvailableGames()
    {
        int? adminId = GetAdminUserId();
        return _videoGamesRepository.GetAllVideoGames().Where(x => x.OwnerId == adminId).ToList();
    }
}
