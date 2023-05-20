using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VideoGamesManager.Models;
using VideoGamesManager.DataAccess.EfModels;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace VideoGamesManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Dbo.User model, string returnUrl = null)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                if (returnUrl != null)
                {
                    return RedirectToAction("Buy", "Purchase");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
