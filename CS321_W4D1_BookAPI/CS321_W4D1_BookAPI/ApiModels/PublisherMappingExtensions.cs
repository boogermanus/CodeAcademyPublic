using CS321_W4D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class PublisherMappingExtensions
    {

        public static PublisherModel ToApiModel(this Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                FoundedYear = publisher.FoundedYear,
                CountryOfOrigin = publisher.CountryOfOrigin,
                HeadQuartersLocation = publisher.HeadQuartersLocation,
                Books = publisher.Books.ToApiModels().ToList()
            };
        }

        public static Publisher ToDomainModel(this PublisherModel publisherModel)
        {
            return new Publisher
            {
                Id = publisherModel.Id,
                CountryOfOrigin = publisherModel.CountryOfOrigin,
                FoundedYear = publisherModel.FoundedYear,
                HeadQuartersLocation = publisherModel.HeadQuartersLocation,
                Name = publisherModel.Name
            };
        }

        public static IEnumerable<PublisherModel> ToApiModels(this IEnumerable<Publisher> publishers)
        {
            return publishers.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Publisher> ToDomainModels(this IEnumerable<PublisherModel> publisherModels)
        {
            return publisherModels.Select(a => a.ToDomainModel());
        }
    }
}
