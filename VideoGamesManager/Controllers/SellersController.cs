using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class SellersController : Controller
    {
        public IActionResult SellerAdd()
        {
            return View();
        }
    }
}
