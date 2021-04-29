using System.Collections.Generic;
using CS321_W4D1_BookAPI.Models;

namespace CS321_W4D1_BookAPI.Services
{
    public interface IPublisherService
    {
        // create
        Publisher Add(Publisher publisher);
        // read
        Publisher Get(int id);
        // update
        Publisher Update(Publisher publisher);
        // delete
        void Remove(Publisher publisher);
        // list
        IEnumerable<Publisher> GetAll();
    }
}