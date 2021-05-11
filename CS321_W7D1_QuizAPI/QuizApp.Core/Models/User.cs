using System;
using Microsoft.AspNetCore.Identity;

namespace QuizApp.Core.Models
{
    public class User : IdentityUser, IEntity<string>
    {
        public string Name { get; set; }
    }
}
