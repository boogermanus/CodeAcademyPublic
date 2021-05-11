using System.Collections.Generic;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeService
    {
        ActivityType Add(ActivityType ActivityType);
        ActivityType Get(int id);
        IEnumerable<ActivityType> GetAll();
        void Remove(ActivityType ActivityType);
        ActivityType Update(ActivityType updatedActivityType);
    }
}