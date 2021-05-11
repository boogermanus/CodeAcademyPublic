using System;
namespace CS321_W5D1_ExerciseLogAPI.Core.Models
{
    public class Activity
    {
        public Activity()
        {
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }
        public double Duration { get; set; }
        public double Distance { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Notes { get; set; }
    }
}
