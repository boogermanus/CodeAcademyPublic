using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS321_W4D2_ExerciseLogAPI.Core.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
    }
}
