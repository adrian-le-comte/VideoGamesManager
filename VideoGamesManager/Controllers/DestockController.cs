using AutoMapper;
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

        public DestockController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
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
