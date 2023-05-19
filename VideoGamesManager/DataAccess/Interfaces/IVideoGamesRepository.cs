namespace VideoGamesManager.DataAccess.Interfaces
{
    public interface IVideoGamesRepository : IRepository<EfModels.Videogame, Dbo.VideoGame>
    {
        Dbo.VideoGame GetVideoGameById(int id);
        List<Dbo.VideoGame> GetAllVideoGames();
        List<Dbo.VideoGame> GetVideoGamesByOwnerId(int owner);
        void AddVideoGames(Dbo.VideoGame videoGame, int amount);
        void RemoveVideoGamesById(int id, int amount);
        void UpdateVideoGames(Dbo.VideoGame videoGame);
    }
}
