using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class SellersController : BaseController
    {
        public SellersController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
        }

        public IActionResult Seller()
        {
            List<Models.SellerViewModel> users = _mapper.Map<List<Models.SellerViewModel>>(_usersRepository.GetAllUsers());
            SellersViewModel viewModel = new SellersViewModel() { Sellers = users };
            return View(viewModel);
        }

        public IActionResult SellerAdd(Dbo.User user)
        {
            _usersRepository.AddUser(user);
            return RedirectToAction("Seller");
        }

        public IActionResult SellerModify(Dbo.User user)
        {
            _usersRepository.UpdateUser(user);
            return RedirectToAction("Seller");
        }

        public IActionResult SellerDelete(int id)
        {
            _usersRepository.DeleteUser(id);
            return View();
        }
    }
}
