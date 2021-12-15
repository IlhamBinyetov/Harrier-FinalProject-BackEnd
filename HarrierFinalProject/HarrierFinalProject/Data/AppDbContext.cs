
using HarrierFinalProject.Data.Configurations;
using HarrierFinalProject.Data.Models;
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
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
       public DbSet<CarStatus> CarStatuses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; } 




        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyDbSeedData(builder);



            builder.ApplyConfigurationsFromAssembly(typeof(BrandConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
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
            new City { Id=7, Name="Lenkeran"},
            new City { Id=8, Name="Kurdemir"}
            );

            builder.Entity<CarType>()
                .HasData(
                new CarType { Id=1, Name="SUV", Image= "car-type7.png" },
                new CarType { Id=2, Name="PickUp", Image= "car-type12.png" },
                new CarType { Id=3, Name="Sedan", Image= "car-type1.png" },
                new CarType { Id=4, Name="Hybrid", Image= "car-type5.png" },
                new CarType { Id=5, Name="Hatchback", Image= "car-type9.png" },
                new CarType { Id=6, Name="Luxury", Image= "car-type10.png" },
                new CarType { Id=7, Name="Coupe", Image="car-type6.png"},
                new CarType { Id=8, Name="Offroader", Image= "car-type12.png" },
                new CarType { Id=9, Name="Minivan", Image= "car-type8.png" },
                new CarType { Id=10, Name="Universal", Image= "car-type7.png" },
                new CarType { Id=11, Name="Truck", Image="car-type2.png"}
                );

            builder.Entity<FuelType>()
                .HasData(
                new FuelType { Id=1, Name="Benzin"},
                new FuelType { Id=2, Name="Dizel"},
                new FuelType { Id=3, Name="Qaz"},
                new FuelType { Id=4, Name="Hibrid"}
                );

            builder.Entity<Transmission>()
                .HasData(
                new Transmission { Id=1, Name="Back"},
                new Transmission { Id=2, Name="Front"},
                new Transmission { Id=3, Name="Full"}
                );

            builder.Entity<Gearbox>()
                .HasData(
                new Gearbox { Id=1, Name="Automatic"},
                new Gearbox { Id=2, Name="Manual"},
                new Gearbox { Id=3, Name="Robotic"},
                new Gearbox { Id=4, Name="Variator"}
                );

            builder.Entity<CarColor>()
              .HasData(
              new CarColor { Id = 1, Name = "Red" },
              new CarColor { Id = 2, Name = "White" },
              new CarColor { Id = 3, Name = "Green" },
              new CarColor { Id = 4, Name = "Black" },
              new CarColor { Id = 5, Name = "Beige" },
              new CarColor { Id = 6, Name = "Blue" },
              new CarColor { Id = 7, Name = "Orange" },
              new CarColor { Id = 8, Name = "Yellow" },
              new CarColor { Id = 9, Name = "Gray" },
              new CarColor { Id = 10, Name = "Dark Gray" },
              new CarColor { Id = 11, Name = "Violet" }
              );

            builder.Entity<Feature>()
                .HasData(
                new Feature {Id = 1, Name = "ABS" },
                new Feature {Id = 2, Name = "Bluetooth" },
                new Feature {Id = 3, Name = "Central Locking" },
                new Feature {Id = 4, Name = "Air Conditioner" },
                new Feature {Id = 5, Name = "Leather Seats" },
                new Feature {Id = 6, Name = "CD Player" },
                new Feature {Id = 7, Name = "Lyuk" },
                new Feature {Id = 8, Name = "Parking radar" },
                new Feature {Id = 9, Name = "Rain Sensor" },
                new Feature {Id = 10, Name = "Heating of seats" },
                new Feature {Id = 11, Name = "Rear View Camera" }
                );

            builder.Entity<Slider>()
                .HasData(
                new Slider { Id=1, Image="slider-1.jpg"},
                new Slider { Id=2, Image="slider-2.jpg"}
                );

        }



    }
}
