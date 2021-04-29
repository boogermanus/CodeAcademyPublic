using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Models
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }
        public double Duration { get; set; }
        public double Distance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Notes { get; set; }
    }
}
