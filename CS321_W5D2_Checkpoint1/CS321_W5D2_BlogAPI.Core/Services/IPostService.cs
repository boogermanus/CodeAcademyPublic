using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public interface IPostService
    {
        Post Add(Post newPost);
        Post Update(Post updatedPost);
        Post Get(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetBlogPosts(int blogId);
        void Remove(int id);
    }
}
