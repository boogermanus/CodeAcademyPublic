using System.Collections.Generic;
using System.Linq;
using CS321_W4D1_BookAPI.Data;
using CS321_W4D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Publisher Add(Publisher publisher)
        {
            _bookContext.Publisher.Add(publisher);
            _bookContext.SaveChanges();

            return publisher;
        }

        public Publisher Get(int id)
        {
            return _bookContext.Publisher
                .Include(p => p.Books)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publisher
                .Include(p => p.Books)
                .ToList();
        }

        public void Remove(Publisher publisher)
        {
            _bookContext.Publisher.Remove(publisher);
            _bookContext.SaveChanges();
        }

        public Publisher Update(Publisher publisher)
        {
            var currentPublisher = Get(publisher.Id);

            if (currentPublisher == null)
                return null;

            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(publisher);

            _bookContext.Update(currentPublisher);
            _bookContext.SaveChanges();

            return currentPublisher;
        }
    }
}