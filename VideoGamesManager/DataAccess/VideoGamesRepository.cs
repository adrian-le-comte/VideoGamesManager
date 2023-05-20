using AutoMapper;
using VideoGamesManager.DataAccess.EfModels;
using VideoGamesManager.Dbo;

namespace VideoGamesManager.DataAccess
{
    public class VideoGamesRepository : Repository<DataAccess.EfModels.Videogame, Dbo.VideoGame>, Interfaces.IVideoGamesRepository
    {
        private readonly IMapper _mapper;
        public VideoGamesRepository(VideoGamesContext context, ILogger<VideoGamesRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async void AddVideoGames(VideoGame videoGame, int amount)
        {
            try
            {
                for (int i = 0; i < amount; i++)
                {
                    await Insert(videoGame);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unhandled exception in AddVideoGames TODO");
                throw e;
            }
            
        }

        public List<VideoGame> GetAllVideoGames()
        {
            return _mapper.Map<List<Dbo.VideoGame>>(_context.Videogames);
        }

        public VideoGame GetVideoGameById(int id)
        {
            var result = _context.Videogames.FirstOrDefault(element => element.Id == id);
            return _mapper.Map<Dbo.VideoGame>(result);
        }

        public List<VideoGame> GetVideoGamesByOwnerId(int ownerId)
        {
            var result = _context.Videogames.Where(element => element.OwnerId == ownerId);
            return _mapper.Map<List<Dbo.VideoGame>>(result);
        }

        public async void RemoveVideoGamesById(int id, int amount)
        {
            try
            {
                for (int i = 0; i < amount; i++)
                {
                    await Delete(id);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unhandled exception in RemoveVideoGamesById TODO");
                throw e;
            }
        }

        public async void UpdateVideoGames(VideoGame videoGame)
        {
            try
            {
                await Update(videoGame);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Unhandled exception in UpdateVideoGames TODO");
                throw e;
            }
        }
    }
}
