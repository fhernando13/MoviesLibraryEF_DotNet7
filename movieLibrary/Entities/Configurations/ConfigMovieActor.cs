using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace movieLibrary.Entities.Configurations
{
    public class ConfigMovieActor: IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(pa => new {pa.Actorid, pa.Movieid});
        }
    }
}