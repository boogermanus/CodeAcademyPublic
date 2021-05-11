using System;
using System.Collections.Generic;

namespace CS321_W5D1_ExerciseLogAPI.ApiModels
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<UserModel> Activities { get; set; }
    }
}
