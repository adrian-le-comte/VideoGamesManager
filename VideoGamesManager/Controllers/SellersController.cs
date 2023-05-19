using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class SellersController : BaseController
    {
        public SellersController(IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository) : base(videoGameRepository, categoryRepository, studioRepository)
        {
        }

        public IActionResult SellerAdd()
        {
            return View();
        }
    }
}
