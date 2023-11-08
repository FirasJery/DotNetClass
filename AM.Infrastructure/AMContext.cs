using ApplicationCore.Domain;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Concert> Concerts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
          Initial Catalog=FestivalsDB;
          Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChansonConfiguration());
            modelBuilder.ApplyConfiguration(new ConcertConfiguration());
            base.OnModelCreating(modelBuilder);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {
            modelConfigurationBuilder.Properties<string>().HaveMaxLength(50);
            base.ConfigureConventions(modelConfigurationBuilder);
        }

    }
}
