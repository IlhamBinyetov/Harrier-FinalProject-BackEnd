using HarrierFinalProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Configurations
{
    public class SettingConfiguration: IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(x => x.HeaderLogo).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Address).HasMaxLength(150);
            builder.Property(x => x.Phone).HasMaxLength(50);
        }
    }
}
