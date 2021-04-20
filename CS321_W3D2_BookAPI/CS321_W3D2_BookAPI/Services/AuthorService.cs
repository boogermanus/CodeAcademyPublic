using System.Collections.Generic;
using System.Linq;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D2_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly BookContext _bookContext;

        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Author Add(Author author)
        {
            _bookContext.Authors.Add(author);
            _bookContext.SaveChanges();
            return author;
        }

        public Author Get(int id)
        {
            // include the books!
            return _bookContext.Authors
                .Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors.Include(a => a.Books).ToList();
        }

        public Author Update(Author updatedAuthor)
        {
            var currentAuthor = _bookContext.Authors.Find(updatedAuthor.Id);

            // return null if todo to update isn't found
            if (currentAuthor == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(updatedAuthor);

            // update the todo and save
            _bookContext.Authors.Update(currentAuthor);
            _bookContext.SaveChanges();
            return currentAuthor;
        }

        public void Remove(Author author)
        {
            // TODO: remove the book
            _bookContext.Authors.Remove(author);
            _bookContext.SaveChanges();
        }

    }
}
