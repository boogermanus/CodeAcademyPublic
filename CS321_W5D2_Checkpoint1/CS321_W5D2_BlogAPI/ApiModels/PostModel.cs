using System;
namespace CS321_W5D2_BlogAPI.ApiModels
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool CommentsAllowed { get; set; }
        public DateTime DatePublished { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string AuthorName { get; set; }
    }
}
