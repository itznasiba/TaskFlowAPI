using youtubeAPI.Core.Entities;
using YoutubeAPI.DataAccess.Repository;

namespace YoutubeAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }
        public void Add(User user)
        {
            _repository.Add(user);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var existingUser = _repository.GetById(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            _repository.Delete(existingUser);
            _repository.Save();
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
            
        }

        public User? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateProfile(User user)
        {
            var existingUser = _repository.GetById(user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            
            existingUser.Email = user.Email;
            existingUser.Name = user.Name;

            _repository.Update(existingUser.Id, existingUser);
            _repository.Save();
        }
    }
}
