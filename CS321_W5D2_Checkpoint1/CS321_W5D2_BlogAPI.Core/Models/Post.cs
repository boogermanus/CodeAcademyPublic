using System;
using System.Collections.Generic;

namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class Post : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public bool CommentsAllowed { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
