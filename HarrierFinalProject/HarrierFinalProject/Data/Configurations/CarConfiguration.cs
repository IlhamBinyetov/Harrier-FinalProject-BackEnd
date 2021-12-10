using HarrierFinalProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Configurations
{
    public class CarConfiguration:IEntityTypeConfiguration<Car>
    {
        public  void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.HorsePower).HasMaxLength(50);
            builder.Property(x => x.Mileage).HasMaxLength(50);
            builder.Property(x => x.MotorPower).HasMaxLength(50);
            builder.Property(x=>x.DateOfProduct).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
