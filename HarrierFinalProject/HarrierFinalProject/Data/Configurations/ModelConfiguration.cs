using HarrierFinalProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarrierFinalProject.Data.Configurations
{
    public class ModelConfiguration: IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.HasOne(x => x.Brand).WithMany(x => x.Models).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
