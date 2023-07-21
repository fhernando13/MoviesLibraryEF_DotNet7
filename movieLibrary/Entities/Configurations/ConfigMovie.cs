using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace movieLibrary.Entities.Configurations
{
    public class ConfMovie: IEntityTypeConfiguration<Movie>
    {
       public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id_movie);
            builder.Property(m => m.Daterelease).HasColumnType("date");

        } 
    }
}