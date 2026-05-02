using TaskAPI.Core.User;

namespace TaskAPI.Business.Services
{
    public interface IUserService
    {
            IEnumerable<UserDto> GetAll();
            UserDto? GetById(int id);
            void Add(UserSaveDto user);
            void UpdateProfile(int id,UserSaveDto user);
            void Delete(int id);
    }
}
