using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class CategoryController : Controller
    {
        public IActionResult CategoryAdd()
        {
            return View();
        }
    }
}
