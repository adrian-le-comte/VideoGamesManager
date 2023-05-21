using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    public class VideoGameController : BaseController
    {
        public VideoGameController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
        }

        public IActionResult VideoGame()
        {
            VideoGamesViewModel viewModel;
            List<Dbo.Category> categories = _categoryRepository.GetAllCategories();
            List<Dbo.Studio> studios = _studioRepository.GetAllStudios();

            List<SelectListItem> categoryOptions = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            List<SelectListItem> studioOptions = studios.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            List<VideoGameViewModel> videoGames = _mapper.Map<List<VideoGameViewModel>>(_videoGamesRepository.GetAllVideoGames());

            viewModel = new VideoGamesViewModel
            {
                CategoryOptions = categoryOptions,
                StudioOptions = studioOptions,
                videoGameViewModels = videoGames
            };

            return View(viewModel);
        }

        public async Task<IActionResult> VideoGameAdd(VideoGamesViewModel viewModel)
        {
            viewModel.Category = _categoryRepository.GetCategoryById(viewModel.CategoryId).Name;
            viewModel.Studio = _studioRepository.GetStudioById(viewModel.CategoryId).Name;
            Dbo.VideoGame game = _mapper.Map<Dbo.VideoGame>(viewModel);
            game.OwnerId = GetCurrentUserId(); // User Admin ID
            game.StudioId = viewModel.StudioId;
            await _videoGamesRepository.AddVideoGames(game);
            

            var categoryOptions = _categoryRepository.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            var studioOptions = _studioRepository.GetAllStudios().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            List<VideoGameViewModel> videoGames = _mapper.Map<List<VideoGameViewModel>>(_videoGamesRepository.GetAllVideoGames());

            viewModel = new VideoGamesViewModel
            {
                CategoryOptions = categoryOptions,
                StudioOptions = studioOptions,
                videoGameViewModels = videoGames
            };

            return View("VideoGame", viewModel);
        }
    }
}
