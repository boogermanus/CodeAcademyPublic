using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
