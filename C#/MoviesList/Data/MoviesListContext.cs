using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesList.Models;

namespace MoviesList.Data
{
    public class MoviesListContext : DbContext
    {
        public MoviesListContext (DbContextOptions<MoviesListContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesList.Models.Movie> Movie { get; set; } = default!;
    }
}
