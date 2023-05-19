namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        Dbo.User GetById(int id);
        List<Dbo.User> GetAllUsers();
    }
}
