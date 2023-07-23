using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace movieLibrary.Entities.Configurations
{
    public class ConfigActor: IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Idactor);
            builder.Property(a => a.Fortune).HasPrecision(18, 2);
            builder.Property(a => a.Birthdate).HasColumnType("date");  
        }
    }
}