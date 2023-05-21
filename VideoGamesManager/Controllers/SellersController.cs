using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class SellersController : BaseController
    {
        UserManager<DataAccess.EfModels.User> _userManager;
        public SellersController(UserManager<DataAccess.EfModels.User> userManager ,IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
            _userManager = userManager;
        }

        public IActionResult Seller()
        {
            List<Models.SellerViewModel> users = _mapper.Map<List<Models.SellerViewModel>>(_usersRepository.GetAllUsers());
            SellersViewModel viewModel = new SellersViewModel() { Sellers = users };
            return View(viewModel);
        }

        public async Task<IActionResult> SellerAdd(SellersViewModel user)
        {
            Dbo.User newUser = _mapper.Map<Dbo.User>(user.Seller);
            List<Models.SellerViewModel> sellers = _mapper.Map<List<Models.SellerViewModel>>(_usersRepository.GetAllUsers());
            bool error = false;
            if (_usersRepository.GetAllUsers().Any(u => u.UserName == user.Seller.Username))
            {
                ModelState.AddModelError("Seller.Username", "Ce nom est déjà utilisé, veuillez en utiliser un autre.");
                error = true;
            }
            if (_usersRepository.GetAllUsers().Any(u => u.Email == user.Seller.Email))
            {
                ModelState.AddModelError("Seller.Email", "Cette adresse email est déjà utilisée, veuillez en utiliser une autre.");
                error = true;
            }
            if (error)
            {
                user.Sellers = sellers;
                return View("Seller", user);
            }
            newUser.Role = "Seller";
            var result = await _userManager.CreateAsync(_mapper.Map<DataAccess.EfModels.User>(newUser), newUser.Password);
            // await _usersRepository.AddUser(newUser);
            Console.WriteLine(result);
            return RedirectToAction("Seller");
        }

        public async Task<IActionResult> SellerModify(Dbo.User user)
        {
            Console.WriteLine("USER ID UPDATE: " + user.Id);
            await _usersRepository.UpdateUser(user);
            return RedirectToAction("Seller");
        }

        public async Task<IActionResult> SellerDelete(int id)
        {
            var isAdmin = _usersRepository.GetById(id).Role == "Admin";
            if (isAdmin)
            {
                SellersViewModel user = new();
                ModelState.AddModelError(string.Empty, "Vous ne pouvez pas supprimer un administrateur.");
                List<Models.SellerViewModel> sellers = _mapper.Map<List<Models.SellerViewModel>>(_usersRepository.GetAllUsers());
                user.Sellers = sellers;
                return View("Seller", user);
            }
            await _usersRepository.DeleteUser(id);
            return RedirectToAction("Seller");
        }
    }
}
