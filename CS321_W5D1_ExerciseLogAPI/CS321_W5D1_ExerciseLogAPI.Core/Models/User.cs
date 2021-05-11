
using Microsoft.AspNetCore.Identity;

namespace CS321_W5D1_ExerciseLogAPI.Core.Models
{
    public class User : IdentityUser
    {
        // we don't need these as they are provided by identity
        // public string Id { get; set; }
        // public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
}
