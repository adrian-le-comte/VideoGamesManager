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

            CreateMap<Dbo.Category, EfModels.Category>();
            CreateMap<EfModels.Category, Dbo.Category>();

            CreateMap<Dbo.Studio, EfModels.Studio>();
            CreateMap<EfModels.Studio, Dbo.Studio>();

            CreateMap<Dbo.User, Models.SellerViewModel>();
            CreateMap<Models.SellerViewModel, Dbo.User>();
        }
    }
}
