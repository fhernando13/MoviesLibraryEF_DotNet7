using movieLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace movieLibrary
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {                        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());                                                                                      
        }
        //Global conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);
        }

        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<MovieActor> MovieActors => Set<MovieActor>();

    }
}