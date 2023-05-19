namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IStudioRepository : IRepository<EfModels.Studio, Dbo.Studio>
    {
        Dbo.Studio GetStudioById(int id);
        List<Dbo.Studio> GetAllStdios();
        void InsertStudio(Dbo.Studio studio);
    }
}
