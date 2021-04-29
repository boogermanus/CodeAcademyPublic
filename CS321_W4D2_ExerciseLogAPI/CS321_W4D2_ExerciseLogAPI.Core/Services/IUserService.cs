using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IUserService
    {
        User Add(User user);
        User Get(int id);
        IEnumerable<User> GetAll();
        User Update(User user);
        void Remove(User user);
    }
}