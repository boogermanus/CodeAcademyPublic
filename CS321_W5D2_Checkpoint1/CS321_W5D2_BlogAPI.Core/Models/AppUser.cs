using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CS321_W5D2_BlogAPI.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Blog> Blogs { get; set; }
    }
}
