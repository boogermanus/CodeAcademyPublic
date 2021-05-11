using System;
namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
