using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;

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
            return View();
        }
    }
}
