using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;

namespace QuizApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        // NOTE: User DbSet is inherited from IdentityDbContext
        // TODO: add DbSets for Quizzes and Questions
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=./quizapp.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<QuizQuestion>()
                .HasKey(qt => new { qt.QuizId, qt.QuestionId });

            SetupSeedData(builder);
        }


        private void SetupSeedData(ModelBuilder modelBuilder)
        {
            // quizzes
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "A Super Tough Quiz",
                    Description = "Some markdown content that describes the quiz.",
                    Instructions = "Some more markdown content that can provide instructions, tips, etc.",
                });

            // questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionType = "chooseOne",
                    Prompt = "Which of the items below is a correct example of an Interface in C#?",
                    //Answers = new List<Answer>()
                });

            // answers
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    QuestionId = 1,
                    IsCorrect = true,
                    Content = @"
```csharp
public interface Foo
{
    void bar();
}
```
",
                },
                new Answer
                {
                    QuestionId = 1,
                    Id = 2,
                    IsCorrect = false,
                    Content = @"
```csharp
public int Foo
{
    void bar();
}
```
",
                },

                    new Answer
                    {
                        QuestionId = 1,
                        Id = 3,
                        IsCorrect = false,
                        Content = @"
```csharp
public interface Foo
[
    void bar();
]
```
",
                });

            modelBuilder.Entity<QuizQuestion>().HasData(
                new QuizQuestion
                {
                    QuizId = 1,
                    QuestionId = 1
                });

        }
    }
}
