using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VideoGamesManager.Models;
using VideoGamesManager.DataAccess.EfModels;

namespace VideoGamesManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Console.WriteLine("Success");
                return RedirectToAction("Index", "Home"); // Redirect to the appropriate dashboard page
            }

            Console.WriteLine("Invalid");
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
    }
}
