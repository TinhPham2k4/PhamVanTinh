﻿using Microsoft.EntityFrameworkCore;
using laptrinhweb2_lythuyet.Models;

namespace laptrinhweb2_lythuyet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between books and authors
            builder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books);

            // Seed database with authors and books for demo
            new DbInitializer(builder).Seed();
        }
    }
}
