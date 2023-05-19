using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VideoGamesManager.Models;
using VideoGamesManager.DataAccess.EfModels;
using System.Security.Cryptography;

namespace VideoGamesManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Dbo.User model)
        {
            Console.WriteLine("USERNAME: " + model.Username);
            var user = await _userManager.FindByEmailAsync(model.Username);
            Console.WriteLine("USER IS :" + user);
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                Console.WriteLine("Success");
                return RedirectToAction("Index", "Home"); // Redirect to the appropriate dashboard page
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
    }
}
