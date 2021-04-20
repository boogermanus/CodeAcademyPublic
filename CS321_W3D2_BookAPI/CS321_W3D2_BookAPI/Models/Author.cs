using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS321_W3D2_BookAPI.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; }
    }
}