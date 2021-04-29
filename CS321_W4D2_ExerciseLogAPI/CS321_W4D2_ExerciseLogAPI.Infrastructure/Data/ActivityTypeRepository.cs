using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public ActivityType Add(ActivityType activityType)
        {
            _dbContext.ActivityTypes.Add(activityType);
            _dbContext.SaveChanges();

            return activityType;
        }

        public ActivityType Get(int id)
        {
            return _dbContext.ActivityTypes.Find(id);
        }

        public ActivityType Update(ActivityType activityType)
        {
            var current = _dbContext.ActivityTypes.Find(activityType.Id);

            if (current == null)
                return null;

            _dbContext.Entry(current)
                .CurrentValues
                .SetValues(activityType);

            _dbContext.SaveChanges();

            return current;
        }

        public void Remove(ActivityType activityType)
        {
            _dbContext.ActivityTypes.Remove(activityType);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes.ToList();
        }
    }
}