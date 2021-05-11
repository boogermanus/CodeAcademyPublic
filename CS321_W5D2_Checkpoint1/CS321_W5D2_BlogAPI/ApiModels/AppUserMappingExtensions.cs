using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.ApiModels
{
	public static class AppUserMappingExtenstions
	{

		public static AppUserModel ToApiModel(this AppUser user)
		{
			return new AppUserModel
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email
			};
		}

		public static AppUser ToDomainModel(this AppUserModel userModel)
		{
			return new AppUser
			{
				Id = userModel.Id,
				FirstName = userModel.FirstName,
				LastName = userModel.LastName,
				Email = userModel.Email
			};
		}

		public static IEnumerable<AppUserModel> ToApiModels(this IEnumerable<AppUser> users)
		{
			return users.Select(a => a.ToApiModel());
		}

		public static IEnumerable<AppUser> ToDomainModels(this IEnumerable<AppUserModel> userModels)
		{
			return userModels.Select(a => a.ToDomainModel());
		}
	}
}
