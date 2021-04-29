using System.Collections.Generic;
using CS321_W4D1_BookAPI.Core.Models;

namespace CS321_W4D1_BookAPI.Core.Services
{
    public interface IBookRepository
    {
        Book Add(Book item);
        Book Get(int id);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksForAuthor(int id);
        void Remove(Book book);
        Book Update(Book updatedBook);
    }
}