using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IntroToRepositoryMVC.Models;

namespace IntroToRepositoryMVC.Data
{
    public class IntroToRepositoryMVCContext : DbContext
    {
        public IntroToRepositoryMVCContext (DbContextOptions<IntroToRepositoryMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasKey(r => new { r.MovieId, r.ActorId });
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Actor> Actor { get; set; } = default!;
        public DbSet<Role> Role { get; set; } = default!;
    }
}
