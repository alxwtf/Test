using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Model
{
    public class Context : IdentityDbContext<User, Role, int>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set;}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserMoviesList> UserMoviesLists { get; set; }
        public DbSet<UserFavourite> UserFavourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenres>()
                        .HasKey(t => new { t.MovieId, t.GenreId });
            modelBuilder.Entity<MovieGenres>()
                        .HasOne(mg => mg.Movie)
                        .WithMany(g => g.MovieGenres)
                        .HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenres>()
                        .HasOne(mg => mg.Genre)
                        .WithMany(g => g.MovieGenres)
                        .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MovieActors>()
                        .HasKey(t => new { t.ActorId, t.MovieId });
            modelBuilder.Entity<MovieActors>()
                        .HasOne(ma => ma.Movie)
                        .WithMany(a => a.MovieActors)
                        .HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieActors>()
                        .HasOne(ma => ma.Actor)
                        .WithMany(a => a.MovieActors)
                        .HasForeignKey(ma => ma.ActorId);
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}