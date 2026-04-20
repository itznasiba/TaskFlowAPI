using youtubeAPI.Core.Entities;

namespace YoutubeAPI.Business.Services
{
    public interface IUserService
    {
            IEnumerable<User> GetAll();
            User? GetById(int id);
            void Add(User user);
            void UpdateProfile(User user);
            void Delete(int id);
    }
}
