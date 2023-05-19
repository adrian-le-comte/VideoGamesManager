using Microsoft.AspNetCore.Mvc;

namespace VideoGamesManager.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryAdd()
        {
            return View();
        }
    }
}
