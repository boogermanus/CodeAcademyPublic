using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D1_ExerciseLogAPI.Core.Models;
using CS321_W5D1_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D1_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity item)
        {
            _dbContext.Activities.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Activity Get(int id)
        {
            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .ToList();
        }

        public Activity Update(Activity updatedActivity)
        {
            // get the ToDo object in the current list with this id 
            var currentActivity = _dbContext.Activities.Find(updatedActivity.Id);

            // return null if todo to update isn't found
            if (currentActivity == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentActivity)
                .CurrentValues
                .SetValues(updatedActivity);

            // update the todo and save
            _dbContext.Activities.Update(currentActivity);
            _dbContext.SaveChanges();
            return currentActivity;
        }

        public void Remove(Activity Activity)
        {
            _dbContext.Activities.Remove(Activity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Activity> GetAllForUser(string userId)
        {
            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .ToList();
        }
    }
}
