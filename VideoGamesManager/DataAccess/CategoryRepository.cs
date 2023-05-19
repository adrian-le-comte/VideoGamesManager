using AutoMapper;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Dbo;

namespace VideoGamesManager.DataAccess
{
    public class CategoryRepository : Repository<DataAccess.EfModels.Category, Dbo.Category>, Interfaces.ICategoryRepository
    {
        public CategoryRepository(EfModels.VideoGamesContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public List<Category> GetAllCategories()
        {
            return _mapper.Map<List<Dbo.Category>>(_context.Categories);
        }

        public Category GetCategoryById(int id)
        {
            return _mapper.Map<Category>(_context.Categories.FirstOrDefault(c => c.Id == id));
        }

        public async void InsertCategory(Category category)
        {
            try
            {
                await Insert(category);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unhandled exception in InsertStudio TODO");
            }
        }
    }
}
