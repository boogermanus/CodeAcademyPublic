using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D1_ExerciseLogAPI.Core.Models;
using CS321_W5D1_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D1_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActivityType Add(ActivityType item)
        {
            _dbContext.ActivityTypes.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public ActivityType Get(int id)
        {
            return _dbContext.ActivityTypes
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes
                .ToList();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            // get the ToDo object in the current list with this id 
            var currentActivityType = _dbContext.ActivityTypes.Find(updatedActivityType.Id);

            // return null if todo to update isn't found
            if (currentActivityType == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentActivityType)
                .CurrentValues
                .SetValues(updatedActivityType);

            // update the todo and save
            _dbContext.ActivityTypes.Update(currentActivityType);
            _dbContext.SaveChanges();
            return currentActivityType;
        }

        public void Remove(ActivityType ActivityType)
        {
            _dbContext.ActivityTypes.Remove(ActivityType);
            _dbContext.SaveChanges();
        }
    }
}
