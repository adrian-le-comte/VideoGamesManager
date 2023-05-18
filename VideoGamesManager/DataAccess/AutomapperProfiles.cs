using AutoMapper;

namespace VideoGamesManager.DataAccess
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Dbo.VideoGame, EfModels.Videogame>();
            CreateMap<EfModels.Videogame, Dbo.VideoGame>();

            CreateMap<Dbo.User, EfModels.User>();
            CreateMap<EfModels.User, Dbo.User>();
        }
    }
}
