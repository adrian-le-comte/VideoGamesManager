namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IStudioRepository : IRepository<EfModels.Studio, Dbo.Studio>
    {
        Dbo.Studio GetStudioById(int id);
        List<Dbo.Studio> GetAllStudios();
        Task AddStudio(Dbo.Studio studio);
        Task DeleteStudio(int id);
    }
}
