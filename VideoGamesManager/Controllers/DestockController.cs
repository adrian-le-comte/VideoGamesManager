using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy ="NonAdminOnly")]
    public class DestockController : BaseController
    {
        private List<Dbo.VideoGame> allSelectedGames = new List<Dbo.VideoGame>();

        public DestockController(IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository) : base(videoGameRepository, categoryRepository, studioRepository)
        {
        }

        public IActionResult GenerateBill()
        {
            var allVideoGames = _videoGamesRepository.GetAllVideoGames();
            var selectedGames = allSelectedGames;
            DestockViewModel viewModel = new DestockViewModel(allVideoGames, selectedGames);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SelectGame(int gameId)
        {
            var game = _videoGamesRepository.GetVideoGameById(gameId);
            allSelectedGames.Add(game);
            return RedirectToAction("GenerateBill");
        }

    }
}
