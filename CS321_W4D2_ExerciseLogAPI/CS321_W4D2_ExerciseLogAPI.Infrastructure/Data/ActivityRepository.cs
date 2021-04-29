using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Activity Add(Activity activity)
        {
            _dbContext.Activities.Add(activity);
            _dbContext.SaveChanges();

            return activity;
        }

        public Activity Get(int id)
        {
            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .FirstOrDefault(a => a.Id == id);
        }

        public Activity Update(Activity activity)
        {
            var current = _dbContext.Activities.Find(activity.Id);

            if (current == null)
                return null;

            _dbContext.Entry(current)
                .CurrentValues
                .SetValues(activity);

            _dbContext.SaveChanges();

            return current;
        }

        public void Remove(Activity activity)
        {
            _dbContext.Activities.Remove(activity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .ToList();
        }
    }
}