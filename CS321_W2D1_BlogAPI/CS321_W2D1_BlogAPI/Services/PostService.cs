using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W2D1_BlogAPI.Models;

namespace CS321_W2D1_BlogAPI.Services
{
    public class PostService : IPostService
    {
        // seed some initial Post data
        private List<Post> _posts = new List<Post>()
        {
            new Post
            {
                Id = 1,
                Title = "My first blog post",
                Body = "Blah blah blah"
            },
            new Post
            {
                Id = 2,
                Title = "My second blog post",
                Body = "Blah blah blah"
            }
        };
        // keep track of next id number
        private int _nextId = 3;

        public Post Add(Post post)
        {
            // assign an id (and then increment _nextId for next time)
            post.Id = _nextId++;
            // store in the list of Posts
            _posts.Add(post);
            // return the new Post with Id filled in
            return post;
        }

        public Post Get(int id)
        {
            // return the specified Post or null if not found
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post Update(Post updatedPost)
        {
            // get the Post object in the current list with this id 
            var currentPost = _posts.FirstOrDefault(p => p.Id == updatedPost.Id);

            // return null if the Post to update isn't found
            if (currentPost == null) return null;

            // copy the property values from the updated post into the current post object
            currentPost.Body = updatedPost.Body;
            currentPost.Title = updatedPost.Title;
            
            return currentPost;
        }

        public void Remove(Post post)
        {
            _posts.Remove(post);
        }
    }
}
