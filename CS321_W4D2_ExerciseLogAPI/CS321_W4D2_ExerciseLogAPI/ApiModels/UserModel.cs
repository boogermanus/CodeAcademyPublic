using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActivityModel> Activities { get; set; }
    }
}
