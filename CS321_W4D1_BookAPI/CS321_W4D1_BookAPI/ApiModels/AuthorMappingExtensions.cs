using CS321_W4D1_BookAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class AuthorMappingExtensions
    {

        public static AuthorModel ToApiModel(this Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate,
            };
        }

        public static Author ToDomainModel(this AuthorModel authorModel)
        {
            return new Author
            {
                Id = authorModel.Id,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,
                BirthDate = authorModel.BirthDate,
            };
        }

        public static IEnumerable<AuthorModel> ToApiModels(this IEnumerable<Author> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Author> ToDomainModels(this IEnumerable<AuthorModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
