using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.ApiModels
{
	public static class PostMappingExtenstions
	{

		public static PostModel ToApiModel(this Post post)
		{
			return new PostModel
			{
				Id = post.Id,
				Title = post.Title,
				Content = post.Content,
				CommentsAllowed = post.CommentsAllowed,
                BlogId = post.BlogId,
                DatePublished = post.DatePublished,
                AuthorName = post?.Blog.User.FullName ?? string.Empty,
                BlogName = post?.Blog.Name ?? string.Empty
			};
		}

		public static Post ToDomainModel(this PostModel postModel)
		{
			return new Post
			{
				Id = postModel.Id,
				Title = postModel.Title,
				Content = postModel.Content,
				CommentsAllowed = postModel.CommentsAllowed,
                BlogId = postModel.BlogId,
                DatePublished = postModel.DatePublished
			};
		}

		public static IEnumerable<PostModel> ToApiModels(this IEnumerable<Post> posts)
		{
			return posts.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Post> ToDomainModels(this IEnumerable<PostModel> postModels)
		{
			return postModels.Select(a => a.ToDomainModel());
		}
	}
}
