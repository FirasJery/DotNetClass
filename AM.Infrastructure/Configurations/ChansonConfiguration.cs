using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ChansonConfiguration : IEntityTypeConfiguration<Chanson>

    {
        public void Configure(EntityTypeBuilder<Chanson> builder)
        {
        }
    }
}
