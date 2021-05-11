using System;
using CS321_W5D1_ExerciseLogAPI.Core.Models;

namespace CS321_W5D1_ExerciseLogAPI.ApiModels
{
    public class ActivityTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordType RecordType { get; set; }
    }
}
