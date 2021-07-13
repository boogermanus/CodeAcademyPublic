using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class JusticeLeagueMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int Age { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActiveMember { get; set; }
        public string UserId {get;set;}
        public ApplicationUser User { get; set; }
    }
}
