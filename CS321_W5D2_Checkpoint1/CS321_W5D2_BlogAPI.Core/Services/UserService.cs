using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;

        public UserService(IHttpContextAccessor httpContext)
        {
            _context = httpContext;
        }

        public ClaimsPrincipal User
        {
            get
            {
                return _context.HttpContext.User;
            }
        }

        //public string GetUser()
        //{
        //    return _context.HttpContext.User?.Identity?.Name;
        //}

        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

    }
}
