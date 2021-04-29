using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityRepository
    {
        Activity Add(Activity todo);
        Activity Get(int id);
        Activity Update(Activity todo);
        void Remove(Activity todo);
        IEnumerable<Activity> GetAll();

    }
}