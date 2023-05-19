using Microsoft.AspNetCore.Mvc;

namespace VideoGamesManager.Controllers
{
    public class DestockController : Controller
    {
        public IActionResult Sold()
        {
            return View();
        }
    }
}
