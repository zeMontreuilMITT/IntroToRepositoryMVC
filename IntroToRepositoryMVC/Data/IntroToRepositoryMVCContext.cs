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

        public DbSet<IntroToRepositoryMVC.Models.Movie> Movie { get; set; } = default!;
    }
}
