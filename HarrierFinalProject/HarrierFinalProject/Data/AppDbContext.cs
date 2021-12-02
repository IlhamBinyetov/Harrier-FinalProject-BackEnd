using HarrierFinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<City> Cities { get; set; }





        public static void ApplyDbSeedData(ModelBuilder builder)
        {
            builder.Entity<Brand>()
                .HasData(
                new Brand { Id=1, Name="Mercedes-Benz"},
                new Brand { Id=2, Name="BMW"},
                new Brand { Id=3, Name="Hyundai"},
                new Brand { Id=4, Name="Kia"},
                new Brand { Id=5, Name="Audi"},
                new Brand { Id=6, Name="Acura"},
                new Brand { Id=7, Name="Toyota"},
                new Brand { Id=8, Name="Nissan"},
                new Brand { Id=9, Name="Chevrolet"},
                new Brand { Id=10, Name="Mazda"}
                );

            builder.Entity<Model>()
                .HasData(
                new Model { Id=1, Name="Gl", BrandId=1},
                new Model { Id=2, Name="Sprinter", BrandId=1},
                new Model { Id=3, Name="E220", BrandId=1},
                new Model { Id=4, Name="X1", BrandId=2},
                new Model { Id=5, Name="X3", BrandId=2},
                new Model { Id=6, Name="X5", BrandId=2},
                new Model { Id=7, Name="X7", BrandId=2},
                new Model { Id=8, Name="Z8", BrandId=2},
                new Model { Id=9, Name="X6", BrandId=2},
                new Model { Id=10, Name="Elantra", BrandId=3},
                new Model { Id=11, Name="Sonata", BrandId=3},
                new Model { Id=12, Name="Tucson", BrandId=3},
                new Model { Id=13, Name="Sorento", BrandId=4},
                new Model { Id=14, Name="Optima", BrandId=4},
                new Model { Id=15, Name="Cerato", BrandId=4},
                new Model { Id=16, Name="A3", BrandId=5},
                new Model { Id=17, Name="A5", BrandId=5},
                new Model { Id=18, Name="A7", BrandId=5},
                new Model { Id=19, Name="A8", BrandId=5},
                new Model { Id=20, Name="Cl", BrandId=6},
                new Model { Id=21, Name="Ilx", BrandId=6},
                new Model { Id=22, Name="Ilx Hybrid", BrandId=6},
                new Model { Id=23, Name="Corolla", BrandId=7},
                new Model { Id=24, Name="Prado", BrandId=7},
                new Model { Id=25, Name="Land Cruiser", BrandId=7},
                new Model { Id=26, Name="Sunny", BrandId=8},
                new Model { Id=27, Name="Altima", BrandId=8},
                new Model { Id=28, Name="X-Trail", BrandId=8},
                new Model { Id=29, Name="Aveo", BrandId=9},
                new Model { Id=30, Name="Cruze", BrandId=9},
                new Model { Id=31, Name="Volt", BrandId=9},
                new Model { Id=32, Name="CX-3", BrandId=10},
                new Model { Id=33, Name="CX-5", BrandId=10},
                new Model { Id=34, Name="Mazda5", BrandId=10}
                );



            builder.Entity<City>()
                .HasData( 
            new City { Id=1, Name="Baku"},
            new City { Id=2, Name="Guba"},
            new City { Id=3, Name="Ganja"},
            new City { Id=4, Name="Sumgayit"},
            new City { Id=5, Name="Shaki"},
            new City { Id=6, Name="Siyezen"},
            new City { Id=6, Name="Lenkeran"},
            new City { Id=6, Name="Kurdemir"}
            );

        }



    }
}
