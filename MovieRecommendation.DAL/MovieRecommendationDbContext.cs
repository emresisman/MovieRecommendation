using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Entities;

namespace MovieRecommendation.DAL
{
    public class MovieRecommendationDbContext : DbContext
    {
        public MovieRecommendationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieNotes> MovieNotes { get; set; }
        public DbSet<MovieRatings> MovieRatings { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieNotes>()
                .HasOne(p => p.Movie)
                .WithMany(b => b.MovieNotes);
        }
    }
}