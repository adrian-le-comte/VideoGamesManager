using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoGamesManager.DataAccess;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    public class BaseController : Controller
    {
        protected IVideoGamesRepository _videoGamesRepository;
        protected ICategoryRepository _categoryRepository;
        protected IStudioRepository _studioRepository;
        public BaseController(IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository)
        {
            _videoGamesRepository = videoGameRepository;
            _categoryRepository = categoryRepository;
            _studioRepository = studioRepository;
        }

        protected int GetCurrentUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
