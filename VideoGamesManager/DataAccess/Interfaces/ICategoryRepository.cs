namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        Dbo.Category GetCategoryById(int id);
        List<Dbo.Category> GetAllCategories();

        void InsertCategory(Dbo.Category category);
    }
}
