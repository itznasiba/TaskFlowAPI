using TaskAPI.Core.User;
using TaskAPI.DataAccess.Repository;
using AutoMapper;
using TaskAPI.Core.Exceptions;

namespace TaskAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(UserSaveDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            _repository.Add(userEntity);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var existingUser = _repository.GetById(id);
            if (existingUser == null)
            {
                throw new NotFoundException($"User with id {id} not found");
            }
            _repository.Delete(existingUser);
            _repository.Save();
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto? GetById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new NotFoundException($"User with id {id} not found");
            }
            return _mapper.Map<UserDto>(user);
        }

        public void UpdateProfile(int id, UserSaveDto user)
        {
            var existingUser = _repository.GetById(id);
            if (existingUser == null)
            {
                throw new NotFoundException($"User with id {id} not found");
            }
            
            var userEntity = _mapper.Map(user, existingUser);

            _repository.Update(existingUser.Id, existingUser);
            _repository.Save();
        }
    }
}
