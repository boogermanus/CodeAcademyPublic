using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                // TODO: fill in property mappings
                // TODO: the ActivityType property should contain the name of the activity type
                // TODO: the User property should contain the user's name
                ActivityTypeId = activity.ActivityTypeId,
                Date = activity.Date,
                Distance = activity.Distance,
                Duration = activity.Duration,
                Notes = activity.Notes,
                UserId = activity.UserId,
                ActivityType = activity.ActivityType.Name,
                User = activity.User?.FullName

            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                // TODO: fill in property mappings
                ActivityTypeId = activityModel.ActivityTypeId,
                Date = activityModel.Date,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                Notes = activityModel.Notes,
                UserId = activityModel.UserId,
                // TODO: leave User and ActivityType null
                User = null,
                ActivityType = null,
            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Activity> activities)
        {
            return activities.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(a => a.ToDomainModel());
        }
    }
}
