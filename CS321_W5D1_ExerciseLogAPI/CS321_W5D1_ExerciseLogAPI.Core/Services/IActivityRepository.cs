using System;
using System.Collections.Generic;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.Core.Services
{
    public interface IActivityRepository
    {
        // create
        Activity Add(Activity todo);
        // read
        Activity Get(int id);
        // update
        Activity Update(Activity todo);
        // delete
        void Remove(Activity todo);
        // list
        IEnumerable<Activity> GetAll();

        IEnumerable<Activity> GetAllForUser(string userId);
    }
}
