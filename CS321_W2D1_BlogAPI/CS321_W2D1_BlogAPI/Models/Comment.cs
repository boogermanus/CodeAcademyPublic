using System;
namespace CS321_W2D1_BlogAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
    }
}
