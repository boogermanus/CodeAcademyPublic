using System;
using CS321_W5D1_ExerciseLogAPI.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D1_ExerciseLogAPI.Infrastructure.Data
{
    // TODO: inherit from IdentityDbContext
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        // NOTE that we don't have to define a Users DbSet. It is given to us by IdentityDbContext.

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Running", RecordType = RecordType.DurationAndDistance },
                new ActivityType { Id = 2, Name = "Weights", RecordType = RecordType.DurationOnly },
                new ActivityType { Id = 3, Name = "Walking", RecordType = RecordType.DurationAndDistance }
            );

            // builder.Entity<User>().HasData(
            //     new User { Id = "123", FirstName = "John", LastName = "Doe" }
            // );
            
            builder.Entity<Activity>().HasData(
                new Activity { Id = 1, UserId = "123", ActivityTypeId = 1, Date = new DateTime(2019, 6, 19), Distance = 3, Duration = 30, Notes = "Hot!!!!" }
            );

        }
    }
}
