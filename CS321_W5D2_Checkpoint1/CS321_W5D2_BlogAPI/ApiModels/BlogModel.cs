using System;
namespace CS321_W5D2_BlogAPI.ApiModels
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string AuthorName { get; set; }
    }
}
