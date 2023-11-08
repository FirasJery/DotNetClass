using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            // foreign keys
            builder
             .HasOne(c => c.Artiste)
             .WithMany(s => s.Concerts)
             .HasForeignKey(c => c.ArtisteFK);

            builder
                .HasOne(c => c.Festival)
                .WithMany(c => c.Concerts)
                .HasForeignKey(c => c.FestivalFK);

            // primary key
            builder.HasKey(c => new { c.ArtisteFK, c.FestivalFK, c.DateConcert });
        }
    }
}
