using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class CategoryController : BaseController
    {
        public CategoryController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }
    }
}
