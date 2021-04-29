using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeRepository
    {
        ActivityType Add(ActivityType todo);
        ActivityType Get(int id);
        ActivityType Update(ActivityType todo);
        void Remove(ActivityType todo);
        IEnumerable<ActivityType> GetAll();

    }
}