using System;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CS321_W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        // TODO: implement a DbSet<Book> property
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookContext(DbContextOptions options) : base(options)
        {
            
        }
        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "J. R. R.",
                    LastName = "Tolkien",
                    BirthDate = new DateTime(1892, 1, 3)
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Charles",
                    LastName = "Stross",
                    BirthDate = new DateTime(1964,10,18),
                }
                ,
                new Author
                {
                    Id = 3,
                    FirstName = "Rudyard",
                    LastName = "Kipling",
                    BirthDate = new DateTime(1865, 12, 30)
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1, Title = "The Fellowship of the Ring", AuthorId = 1, Category = "Fantasy",
                },
                new Book
                {
                    Id = 2, Title = "Glasshouse", AuthorId = 2 , Category = "SciFi"
                },
                new Book
                {
                    Id = 3, Title = "Just So Stories", AuthorId = 3, Category = "Fiction"
                }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}

