using Microsoft.AspNetCore.Mvc;

namespace VideoGamesManager.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult SellerAdd()
        {
            return View();
        }
    }
}
