namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IStudioRepository
    {
        Dbo.Studio GetStudioById(int id);
        List<Dbo.Studio> GetAllStdios();
        void InsertStudio(Dbo.Studio studio);
    }
}
