using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManager.DataAccess;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class CategoryController : BaseController
    {
        public CategoryController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
        }

        public IActionResult Category()
        {
            List<Models.CategoryViewModel> categories = _mapper.Map<List<Models.CategoryViewModel>>(_categoryRepository.GetAllCategories());
            CategoriesViewModel viewModel = new CategoriesViewModel() { Categories = categories };
            return View(viewModel);
        }

        public async Task<IActionResult> CategoryAdd([Bind("Category")] CategoriesViewModel cat)
        {
           if (_categoryRepository.GetAllCategories().Any(u => u.Name == cat.Category.Name))
            {
                ModelState.AddModelError("Category.Name", "Cette catégorie existe déjà, veuillez en ajouter une autre.");
                cat.Categories = _mapper.Map<List<Models.CategoryViewModel>>(_categoryRepository.GetAllCategories());
                return View("Category", cat);
            }
            Dbo.Category newCategory = _mapper.Map<Dbo.Category>(cat.Category);
            List<Models.CategoryViewModel> categories = _mapper.Map<List<Models.CategoryViewModel>>(_categoryRepository.GetAllCategories());

            await _categoryRepository.AddCategory(newCategory);
            return RedirectToAction("Category");
        }

        public async Task<IActionResult> CategoryDelete(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Category");
        }
    }
}
