using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;
        
        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post Get(int id)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .ThenInclude(b => b.User)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .ThenInclude(b => b.User)
                .Where(p => p.BlogId == blogId)
                .ToList();
        }

        public Post Add(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return post;
        }

        public Post Update(Post post)
        {
            var current = _dbContext.Posts.Find(post.Id);

            if (current == null)
                return null;

            _dbContext.Entry(current)
                .CurrentValues
                .SetValues(post);

            _dbContext.Update(current);
            _dbContext.SaveChanges();

            return current;
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts.ToList();
        }

        public void Remove(int id)
        {
            var current = _dbContext.Posts
                .FirstOrDefault(p => p.Id == id);

            _dbContext.Posts.Remove(current);
            _dbContext.SaveChanges();
        }

    }
}
