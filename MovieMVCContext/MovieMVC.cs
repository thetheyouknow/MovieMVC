using System;
using Microsoft.EntityFrameworkCore;

//namespace MovieMVCContext
namespace Packt.Shared
{
    public class MovieMVC : DbContext
    {
        public DbSet<Country> Countries {get;set;}
        public DbSet<Director> Directors {get;set;}
        public DbSet<Genre> Genres {get;set;}// no "Genres" in name; has to match the database table 
        public DbSet<Language> Languages {get;set;}
        public DbSet<Movie> Movies {get;set;}////s
        public DbSet<MovieCountry> MovieCountries {get;set;}
        public DbSet<MovieDirector> MovieDirectors {get;set;}
        public DbSet<MovieGenre> MovieGenres {get;set;}
        public DbSet<MovieLanguage> MovieLanguages {get;set;}
        public DbSet<Rating> Ratings {get;set;}
        public DbSet<Streaming> Streamings {get;set;}

        public MovieMVC(DbContextOptions<MovieMVC> options) : base(options) { }

        protected override void OnModelCreating( ModelBuilder modelBuilder)  {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Movie>().Property(m => m.Year).IsRequired().HasMaxLength(20);
        //modelBuilder.Entity<Movie>().Property(m => m.Title).IsRequired().HasMaxLength(600);
            //modelBuilder.Entity<Movie>().Property(m => m.MovieID).IsRequired();

            modelBuilder.Entity<Movie>().HasKey(m => m.MovieID);
            modelBuilder.Entity<Rating>().Property(r => r.RatingID).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<MovieCountry>(r => r.HasNoKey());
            //modelBuilder.Entity<MovieDirector>(r => r.HasNoKey());
            modelBuilder.Entity<MovieGenre>(r => r.HasNoKey());
            modelBuilder.Entity<MovieLanguage>(r => r.HasNoKey());

            modelBuilder.Entity<MovieDirector>().HasKey(l => new { l.DirectorID, l.MovieID });
            modelBuilder.Entity<Director>().HasKey(l => l.DirectorID);


    }
    }
}
