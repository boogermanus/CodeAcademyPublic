using System;
using System.Collections.Generic;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private IActivityTypeRepository _activityTypeRepo;

        public ActivityTypeService(IActivityTypeRepository ActivityTypeRepo)
        {
            _activityTypeRepo = ActivityTypeRepo;
        }

        public ActivityType Add(ActivityType ActivityType)
        {
            // TODO: implement add
            _activityTypeRepo.Add(ActivityType);
            return ActivityType;
        }

        public ActivityType Get(int id)
        {
            // TODO: return the specified ActivityType using Find()
            return _activityTypeRepo.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            // TODO: return all ActivityTypes using ToList()
            return _activityTypeRepo.GetAll();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            // update the todo and save
            var ActivityType = _activityTypeRepo.Update(updatedActivityType);
            return ActivityType;
        }

        public void Remove(ActivityType ActivityType)
        {
            // TODO: remove the ActivityType
            _activityTypeRepo.Remove(ActivityType);
        }

    }

}
