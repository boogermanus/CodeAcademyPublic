using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public User Get(int id)
        {
            return _dbContext.Users
                .Include(u => u.Activities)
                .ThenInclude(a => a.ActivityType)
                .FirstOrDefault(u => u.Id == id);
        }

        public User Update(User user)
        {
            var current = _dbContext.Users.Find(user.Id);

            if (current == null)
                return null;

            _dbContext.Entry(current)
                .CurrentValues
                .SetValues(user);

            _dbContext.SaveChanges();

            return current;
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users
                .Include(u => u.Activities)
                .ThenInclude(a => a.ActivityType)
                .ToList();
        }
    }
}