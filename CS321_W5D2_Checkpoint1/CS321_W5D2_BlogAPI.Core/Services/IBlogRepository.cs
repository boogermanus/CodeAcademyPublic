using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public interface IBlogRepository
    {
        Blog Add(Blog blog);
        Blog Update(Blog blog);
        Blog Get(int id);
        IEnumerable<Blog> GetAll();
        void Remove(int id);
    }
}
