using System;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public class ActivityTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordType RecordType { get; set; }
    }
}
