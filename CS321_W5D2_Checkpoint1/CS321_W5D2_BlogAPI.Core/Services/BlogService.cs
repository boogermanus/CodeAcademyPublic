using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        // TODO: inject IBlogRepository
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Blog Add(Blog newBlog)
        {
            return _blogRepository.Add(newBlog);
        }

        public Blog Get(int id)
        {
            return _blogRepository.Get(id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public void Remove(int id)
        {
            _blogRepository.Remove(id);
        }

        public Blog Update(Blog updatedBlog)
        {
            return _blogRepository.Update(updatedBlog);
        }
    }
}
