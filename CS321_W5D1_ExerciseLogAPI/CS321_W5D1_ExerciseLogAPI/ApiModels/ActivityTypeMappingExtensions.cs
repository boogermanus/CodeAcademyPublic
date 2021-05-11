using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.ApiModels
{
    public static class ActivityTypeMappingExtenstions
    {

        public static ActivityTypeModel ToApiModel(this ActivityType ActivityType)
        {
            return new ActivityTypeModel
            {
                Id = ActivityType.Id,
                // TODO: fill in property mappings
            };
        }

        public static ActivityType ToDomainModel(this ActivityTypeModel ActivityTypeModel)
        {
            return new ActivityType
            {
                Id = ActivityTypeModel.Id,
                // TODO: fill in property mappings
            };
        }

        public static IEnumerable<ActivityTypeModel> ToApiModels(this IEnumerable<ActivityType> ActivityTypes)
        {
            return ActivityTypes.Select(a => a.ToApiModel());
        }

        public static IEnumerable<ActivityType> ToDomainModels(this IEnumerable<ActivityTypeModel> ActivityTypeModels)
        {
            return ActivityTypeModels.Select(a => a.ToDomainModel());
        }
    }
}
