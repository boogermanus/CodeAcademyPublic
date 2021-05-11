using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.ApiModels
{
    public static class BlogMappingExtenstions
    {

        public static BlogModel ToApiModel(this Blog blog)
        {
            return new BlogModel
            {
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                AuthorName = blog?.User.FullName ?? string.Empty,
                UserId = blog.UserId
            };
        }

        public static Blog ToDomainModel(this BlogModel blogModel)
        {
            return new Blog
            {
                Id = blogModel.Id,
                Name = blogModel.Name,
                Description = blogModel.Description,
            };
        }

        public static IEnumerable<BlogModel> ToApiModels(this IEnumerable<Blog> blogs)
        {
            return blogs.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Blog> ToDomainModels(this IEnumerable<BlogModel> blogs)
        {
            return blogs.Select(a => a.ToDomainModel());
        }
    }
}
