using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy ="NonAdminOnly")]
    public class DestockController : Controller
    {
        public IActionResult GenerateBill()
        {
            return View();
        }
    }
}
