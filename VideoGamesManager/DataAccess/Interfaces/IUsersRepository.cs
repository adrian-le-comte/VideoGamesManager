namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IUsersRepository : IRepository<EfModels.User, Dbo.User>
    {
        Dbo.User GetById(int id);
        List<Dbo.User> GetAllUsers();
        void AddUser(Dbo.User user);
        void UpdateUser(Dbo.User user);
        void DeleteUser(int id);

    }
}
