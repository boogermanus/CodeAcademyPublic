using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IUserRepository
    {
        User Add(User todo);
        User Get(int id);
        User Update(User todo);
        void Remove(User todo);
        IEnumerable<User> GetAll();

    }
}