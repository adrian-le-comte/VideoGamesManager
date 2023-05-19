namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<EfModels.Category, Dbo.Category>
    {
        Dbo.Category GetCategoryById(int id);
        List<Dbo.Category> GetAllCategories();

        void InsertCategory(Dbo.Category category);
    }
}
