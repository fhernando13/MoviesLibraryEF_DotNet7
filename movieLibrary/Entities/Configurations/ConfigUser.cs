using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace movieLibrary.Entities.Configurations
{
    public class ConfigUser: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Iduser);
            builder.Property(a => a.Birthdate).HasColumnType("date");  
        }
    }
}