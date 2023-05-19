using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class CategoryController : BaseController
    {
        public CategoryController(IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository) : base(videoGameRepository, categoryRepository, studioRepository)
        {
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }
    }
}
