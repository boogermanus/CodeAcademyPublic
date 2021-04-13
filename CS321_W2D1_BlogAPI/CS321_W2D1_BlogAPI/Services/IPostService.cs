using System;
using System.Collections.Generic;
using CS321_W2D1_BlogAPI.Models;

namespace CS321_W2D1_BlogAPI.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Post Get(int id);
        Post Add(Post post);
        void Remove(Post post);
        Post Update(Post post);
    }
}
