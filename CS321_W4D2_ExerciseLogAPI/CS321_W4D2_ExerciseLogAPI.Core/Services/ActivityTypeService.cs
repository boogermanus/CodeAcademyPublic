using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private IActivityTypeRepository _activityTypeRepository;

        public ActivityTypeService(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        public ActivityType Add(ActivityType activityType)
        {
            return _activityTypeRepository.Add(activityType);
        }

        public ActivityType Get(int id)
        {
            return _activityTypeRepository.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _activityTypeRepository.GetAll();
        }

        public ActivityType Update(ActivityType activityType)
        {
            return _activityTypeRepository.Update(activityType);
        }

        public void Remove(ActivityType activityType)
        {
            _activityTypeRepository.Remove(activityType);
        }
    }
}