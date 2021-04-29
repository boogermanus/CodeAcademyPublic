using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Activities = user.Activities.ToApiModels().ToList()
            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Name = userModel.Name
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> users)
        {
            return users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> userModels)
        {
            return userModels.Select(a => a.ToDomainModel());
        }
    }
}
