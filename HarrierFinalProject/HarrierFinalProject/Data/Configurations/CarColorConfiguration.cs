using HarrierFinalProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarrierFinalProject.Data.Configurations
{
    public class CarColorConfiguration: IEntityTypeConfiguration<CarColor>
    {
        public void Configure(EntityTypeBuilder<CarColor> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
        }
    }
}
