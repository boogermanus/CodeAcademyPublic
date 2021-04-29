using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Models
{
    public enum RecordType
    {
        DurationOnly, // only record duration
        DurationAndDistance // record duration and distance
    }

    public class ActivityType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordType RecordType { get; set; }
    }
}
