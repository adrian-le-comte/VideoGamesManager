using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy ="NonAdminOnly")]
    public class DestockController : BaseController
    {

        public DestockController(IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository) : base(videoGameRepository, categoryRepository, studioRepository)
        {
        }

        public IActionResult GenerateBill()
        {
            var allVideoGames = _videoGamesRepository.GetAllVideoGames();

            var selectedGamesJson = TempData["SelectedGames"] as string;
            var selectedGames = new List<Dbo.VideoGame>();
            if (selectedGamesJson != null)
            {
                selectedGames = JsonConvert.DeserializeObject<List<Dbo.VideoGame>>(selectedGamesJson);
            }
            if (selectedGames == null)
            {
                selectedGames = new List<Dbo.VideoGame>();
            }
            DestockViewModel viewModel = new DestockViewModel(allVideoGames, selectedGames);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGame(string Name, string Price, string Stock, string gameId)
        {
            var id = int.Parse(gameId);
            var game = _videoGamesRepository.GetVideoGameById(id);
            game.Stock = int.Parse(Stock);
            var selectedGames = new List<Dbo.VideoGame>();
            var selectedGamesJson = TempData["SelectedGames"] as string;
            if (!string.IsNullOrEmpty(selectedGamesJson))
            {
                selectedGames = JsonConvert.DeserializeObject<List<Dbo.VideoGame>>(selectedGamesJson);
            }

            selectedGames.Add(game);

            selectedGamesJson = JsonConvert.SerializeObject(selectedGames);
            TempData["SelectedGames"] = selectedGamesJson;
            return RedirectToAction("GenerateBill");
        }

    }
}
