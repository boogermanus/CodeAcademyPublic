using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;

namespace QuizApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        // NOTE: User DbSet is inherited from IdentityDbContext...far out.
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../QuizApp.Infrastructure/quizapp.db");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<QuizQuestion>()
                .HasKey(qt => new {qt.QuizId, qt.QuestionId});
            base.OnModelCreating(builder);
        }

    }
}
