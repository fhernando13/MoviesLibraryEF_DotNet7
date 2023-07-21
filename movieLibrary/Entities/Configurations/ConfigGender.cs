using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace movieLibrary.Entities.Configurations
{
    public class ConfGender: IEntityTypeConfiguration<Gender>
    {
         public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.Id_gender);
        }
    }
}