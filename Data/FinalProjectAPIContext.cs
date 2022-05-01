#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProjectAPI.Models;

namespace FinalProjectAPI.Data
{
    public class FinalProjectAPIContext : DbContext
    {
        public FinalProjectAPIContext (DbContextOptions<FinalProjectAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<seriedetail> Seriedetail { get; set; }
        public DbSet<UserRate> userRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRate>()
                .HasOne(p => p.movie)
                .WithMany(b => b.userrate)
                .HasForeignKey(p => p.movieid);
        }


    }
}
