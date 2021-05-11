using System.Collections.Generic;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.Core.Services
{
    public interface IActivityService
    {
        Activity Add(Activity Activity);
        Activity Get(int id);
        IEnumerable<Activity> GetAll();
        void Remove(Activity Activity);
        Activity Update(Activity updatedActivity);
        IEnumerable<Activity> GetAllForUser(string userId);
    }
}