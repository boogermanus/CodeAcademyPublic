using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                Date = activity.Date,
                ActivityType = activity.ActivityType.Name,
                User = activity.User.Name,
                Distance = activity.Distance,
                Duration = activity.Duration
            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                UserId = activityModel.UserId,
                ActivityTypeId = activityModel.ActivityTypeId,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                Notes = activityModel.Notes
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
