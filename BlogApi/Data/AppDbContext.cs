using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace BlogApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }
    }
}
