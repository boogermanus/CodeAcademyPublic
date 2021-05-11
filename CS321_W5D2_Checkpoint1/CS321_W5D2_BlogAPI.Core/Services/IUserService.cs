using System.Security.Claims;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public interface IUserService
    {
        ClaimsPrincipal User { get; }
        string CurrentUserId { get; }
    }
}