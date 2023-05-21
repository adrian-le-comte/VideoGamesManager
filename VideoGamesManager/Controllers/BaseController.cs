using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoGamesManager.DataAccess;
using VideoGamesManager.DataAccess.Interfaces;

namespace VideoGamesManager.Controllers
{
    public class BaseController : Controller
    {
        protected IMapper _mapper;
        protected IVideoGamesRepository _videoGamesRepository;
        protected ICategoryRepository _categoryRepository;
        protected IStudioRepository _studioRepository;
        protected IUsersRepository _usersRepository;
        public BaseController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _videoGamesRepository = videoGameRepository;
            _categoryRepository = categoryRepository;
            _studioRepository = studioRepository;
            _usersRepository = usersRepository;
        }

        protected int GetCurrentUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        protected int GetAdminUserId()
        {
            return _usersRepository.GetAllUsers().Find(x => x.Role == "Admin").Id;
        }
    }
}
