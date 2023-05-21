using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy ="AdminOnly")]
    public class StudioController : BaseController
    {
        public StudioController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository StudioRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
        }

        public IActionResult Studio()
        {
            List<Models.StudioViewModel> Studios = _mapper.Map<List<Models.StudioViewModel>>(_studioRepository.GetAllStudios());
            StudiosViewModel viewModel = new StudiosViewModel() { Studios = Studios };
            return View(viewModel);
        }

        public async Task<IActionResult> StudioAdd([Bind("Studio")] StudiosViewModel cat)
        {
            if (_studioRepository.GetAllStudios().Any(u => u.Name == cat.Studio.Name))
            {
                ModelState.AddModelError("Studio.Name", "Ce studio existe déjà, veuillez en ajouter un autr.");
                cat.Studios = _mapper.Map<List<Models.StudioViewModel>>(_studioRepository.GetAllStudios());
                return View("Studio", cat);
            }
            Dbo.Studio newStudio = _mapper.Map<Dbo.Studio>(cat.Studio);
            List<Models.StudioViewModel> Studios = _mapper.Map<List<Models.StudioViewModel>>(_studioRepository.GetAllStudios());

            await _studioRepository.AddStudio(newStudio);
            return RedirectToAction("Studio");
        }

        public async Task<IActionResult> StudioDelete(int id)
        {
            await _studioRepository.DeleteStudio(id);
            return RedirectToAction("Studio");
        }
    }
}
