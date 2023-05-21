namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IVideoGamesRepository : IRepository<EfModels.Videogame, Dbo.VideoGame>
    {
        Dbo.VideoGame GetVideoGameById(int id);
        Dbo.VideoGame GetVideoGameByName(string name);
        Dbo.VideoGame GetVideoGameByNameAndOwner(string name, int ownerId);

        List<Dbo.VideoGame> GetAllVideoGames();
        List<Dbo.VideoGame> GetVideoGamesByOwnerId(int owner);
        Task AddVideoGames(Dbo.VideoGame videoGame);
        Task RemoveVideoGamesById(int id, int amount);
        Task UpdateVideoGames(Dbo.VideoGame videoGame);
    }
}
