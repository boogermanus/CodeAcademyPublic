using CS321_W4D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class BookMappingExtensions
    {

        public static BookModel ToApiModel(this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Author = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : string.Empty,
                Genre = book.Genre,
                PublisherId = book.PublisherId,
                Publisher = book.Publisher != null ? $"{book.Publisher.Name}, {book.Publisher.CountryOfOrigin}, {book.Publisher.HeadQuartersLocation}" : string.Empty,
                OriginalLanguage = book.OriginalLanguage
            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                OriginalLanguage = bookModel.OriginalLanguage,
                Genre = bookModel.Genre,
                PublicationYear = bookModel.PublicationYear,
                PublisherId = bookModel.PublisherId,
                AuthorId = bookModel.AuthorId
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModels(this IEnumerable<BookModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
