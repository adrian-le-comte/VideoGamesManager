using AutoMapper;
using VideoGamesManager.Dbo;

namespace VideoGamesManager.DataAccess
{
    public class StudioRepository : Repository<DataAccess.EfModels.Studio, Dbo.Studio>, Interfaces.IStudioRepository
    {
        public StudioRepository(EfModels.VideoGamesContext context, ILogger<StudioRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public List<Studio> GetAllStdios()
        {
            return _mapper.Map<List<Dbo.Studio>>(_context.Studios);
        }

        public Studio GetStudioById(int id)
        {
            var result = _context.Studios.FirstOrDefault(s => s.Id == id);
            return _mapper.Map<Dbo.Studio>(result);
        }

        public async void InsertStudio(Studio studio)
        {
            try
            {
                await Insert(studio);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unhandled exception in InsertStudio TODO");
            }
        }
    }
}
