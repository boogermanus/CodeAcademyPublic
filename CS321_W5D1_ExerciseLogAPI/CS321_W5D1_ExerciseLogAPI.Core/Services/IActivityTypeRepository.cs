using System;
using System.Collections.Generic;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeRepository
    {
        // create
        ActivityType Add(ActivityType todo);
        // read
        ActivityType Get(int id);
        // update
        ActivityType Update(ActivityType todo);
        // delete
        void Remove(ActivityType todo);
        // list
        IEnumerable<ActivityType> GetAll();
    }
}
