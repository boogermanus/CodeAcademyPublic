using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IUserService _userService;

        public PostService(IPostRepository postRepository, IBlogRepository blogRepository, IUserService userService)
        {
            _postRepository = postRepository;
            _blogRepository = blogRepository;
            _userService = userService;
        }

        public Post Add(Post newPost)
        {
            var blog = _blogRepository.Get(newPost.BlogId);

            if (blog == null)
                throw new ApplicationException($"blog {newPost.Id} not found");

            if (blog.UserId != _userService.CurrentUserId)
                throw new ApplicationException(
                    $"unable to add to blog {newPost.BlogId} for user {_userService.CurrentUserId}");
            
            newPost.DatePublished = DateTime.Now;
            
            return _postRepository.Add(newPost);
        }

        public Post Get(int id)
        {
            return _postRepository.Get(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }
        
        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _postRepository.GetBlogPosts(blogId);
        }

        public void Remove(int id)
        {
            var post = Get(id);

            if (post.Blog.UserId != _userService.CurrentUserId)
                throw new ApplicationException($"unable to remove post {id} for user {_userService.CurrentUserId}");
            
            _postRepository.Remove(id);
        }

        public Post Update(Post updatedPost)
        {
            var current = Get(updatedPost.Id);

            if (current.Blog.UserId != _userService.CurrentUserId)
                throw new ApplicationException(
                    $"unable to update post {updatedPost.Id} for user {_userService.CurrentUserId}");
            
            return _postRepository.Update(updatedPost);
        }

    }
}
