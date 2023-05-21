namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IUsersRepository : IRepository<EfModels.User, Dbo.User>
    {
        Dbo.User GetById(long id);
        List<Dbo.User> GetAllUsers();
        Task AddUser(Dbo.User user);
        Task UpdateUser(Dbo.User user);
        Task DeleteUser(int id);

    }
}
