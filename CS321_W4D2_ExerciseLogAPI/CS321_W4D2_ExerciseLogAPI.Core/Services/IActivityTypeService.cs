using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeService
    {
        ActivityType Add(ActivityType activityType);
        ActivityType Get(int id);
        IEnumerable<ActivityType> GetAll();
        ActivityType Update(ActivityType activityType);
        void Remove(ActivityType activityType);
    }
}