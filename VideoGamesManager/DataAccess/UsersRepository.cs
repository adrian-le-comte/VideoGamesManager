using AutoMapper;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using VideoGamesManager.Dbo;

namespace VideoGamesManager.DataAccess
{
    public class UsersRepository : Repository<DataAccess.EfModels.User, Dbo.User>, Interfaces.IUsersRepository
    {
        public UsersRepository(EfModels.VideoGamesContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public User? GetById(int id)
        {
            var result = _context.Users.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<User>(result);
        }

        public async void AddUser(User user)
        {
            try
            {
                await Insert(user);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unhandled exception in AddUser TODO");
                throw ex;
            }
        }

        public async void UpdateUser(User user)
        {
            try
            {
                await Update(user);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unhandled exception in UpdateUser TODO");
                throw ex;
            }
        }

        public async void DeleteUser(int id)
        {
            try
            {
                await Delete(id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unhandled exception in DeleteUser TODO");
                throw ex;
            }
        }

        public List<User> GetAllUsers()
        {
            return _mapper.Map<List<Dbo.User>>(_context.Users);
        }
    }
}
