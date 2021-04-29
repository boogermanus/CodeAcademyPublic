using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;

        public ActivityService(IActivityRepository activityRepository, IActivityTypeRepository activityTypeRepository)
        {
            _activityRepository = activityRepository;
            _activityTypeRepository = activityTypeRepository;
        }

        public Activity Add(Activity activity)
        {
            var activityType = _activityTypeRepository.Get(activity.ActivityTypeId);

            if (activityType == null)
                throw new Exception("Invalid activity type");

            switch (activityType.RecordType)
            {
                case RecordType.DurationOnly:
                    if (activity.Duration < 0)
                        throw new Exception("Duration must be greater than 0");
                    break;
                case RecordType.DurationAndDistance:
                    if (activity.Distance < 0)
                        throw new Exception("Distance must be greater than 0");

                    if (activity.Duration < 0)
                        throw new Exception("Duration must be greater than 0");
                    break;
            }

            return _activityRepository.Add(activity);
        }

        public Activity Get(int id)
        {
            return _activityRepository.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _activityRepository.GetAll();
        }

        public Activity Update(Activity activity)
        {
            return _activityRepository.Update(activity);
        }

        public void Remove(Activity activity)
        {
            _activityRepository.Remove(activity);
        }
    }
}