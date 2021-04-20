namespace CS321_W3D1_BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        // relation properties
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
