using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public void Remove(User user)
        {
            _userRepository.Remove(user);
        }
    }
}