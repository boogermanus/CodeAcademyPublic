using System;
using System.Collections.Generic;

namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class Blog : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
