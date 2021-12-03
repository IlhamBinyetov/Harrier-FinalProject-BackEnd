﻿// <auto-generated />
using System;
using HarrierFinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HarrierFinalProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211203063340_ImageDataAddedtoCarTypeTable")]
    partial class ImageDataAddedtoCarTypeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HarrierFinalProject.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hyundai"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Acura"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Mazda"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.CarColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarColors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 2,
                            Name = "White"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Green"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Beige"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Orange"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Yellow"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Gray"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Dark Gray"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Violet"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "car-type7.png",
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 2,
                            Image = "car-type12.png",
                            Name = "PickUp"
                        },
                        new
                        {
                            Id = 3,
                            Image = "car-type1.png",
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 4,
                            Image = "car-type5.png",
                            Name = "Hybrid"
                        },
                        new
                        {
                            Id = 5,
                            Image = "car-type9.png",
                            Name = "Hatchback"
                        },
                        new
                        {
                            Id = 6,
                            Image = "car-type10.png",
                            Name = "Luxury"
                        },
                        new
                        {
                            Id = 7,
                            Image = "car-type6.png",
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 8,
                            Image = "car-type12.png",
                            Name = "Offroader"
                        },
                        new
                        {
                            Id = 9,
                            Image = "car-type7.png",
                            Name = "Minivan"
                        },
                        new
                        {
                            Id = 10,
                            Image = "car-type7.png",
                            Name = "Universal"
                        },
                        new
                        {
                            Id = 11,
                            Image = "car-type2.png",
                            Name = "Truck"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Baku"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Guba"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ganja"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sumgayit"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Shaki"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Siyezen"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Lenkeran"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Kurdemir"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ABS"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bluetooth"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Central Locking"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Air Conditioner"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Leather Seats"
                        },
                        new
                        {
                            Id = 6,
                            Name = "CD Player"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Lyuk"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Parking radar"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Rain Sensor"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Heating of seats"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Rear View Camera"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Benzin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dizel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Qaz"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hibrid"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.Gearbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gearboxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Automatic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manual"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Robotic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Variator"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "Gl"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Name = "Sprinter"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Name = "E220"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Name = "X1"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            Name = "X3"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            Name = "X5"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 2,
                            Name = "X7"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 2,
                            Name = "Z8"
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 2,
                            Name = "X6"
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 3,
                            Name = "Elantra"
                        },
                        new
                        {
                            Id = 11,
                            BrandId = 3,
                            Name = "Sonata"
                        },
                        new
                        {
                            Id = 12,
                            BrandId = 3,
                            Name = "Tucson"
                        },
                        new
                        {
                            Id = 13,
                            BrandId = 4,
                            Name = "Sorento"
                        },
                        new
                        {
                            Id = 14,
                            BrandId = 4,
                            Name = "Optima"
                        },
                        new
                        {
                            Id = 15,
                            BrandId = 4,
                            Name = "Cerato"
                        },
                        new
                        {
                            Id = 16,
                            BrandId = 5,
                            Name = "A3"
                        },
                        new
                        {
                            Id = 17,
                            BrandId = 5,
                            Name = "A5"
                        },
                        new
                        {
                            Id = 18,
                            BrandId = 5,
                            Name = "A7"
                        },
                        new
                        {
                            Id = 19,
                            BrandId = 5,
                            Name = "A8"
                        },
                        new
                        {
                            Id = 20,
                            BrandId = 6,
                            Name = "Cl"
                        },
                        new
                        {
                            Id = 21,
                            BrandId = 6,
                            Name = "Ilx"
                        },
                        new
                        {
                            Id = 22,
                            BrandId = 6,
                            Name = "Ilx Hybrid"
                        },
                        new
                        {
                            Id = 23,
                            BrandId = 7,
                            Name = "Corolla"
                        },
                        new
                        {
                            Id = 24,
                            BrandId = 7,
                            Name = "Prado"
                        },
                        new
                        {
                            Id = 25,
                            BrandId = 7,
                            Name = "Land Cruiser"
                        },
                        new
                        {
                            Id = 26,
                            BrandId = 8,
                            Name = "Sunny"
                        },
                        new
                        {
                            Id = 27,
                            BrandId = 8,
                            Name = "Altima"
                        },
                        new
                        {
                            Id = 28,
                            BrandId = 8,
                            Name = "X-Trail"
                        },
                        new
                        {
                            Id = 29,
                            BrandId = 9,
                            Name = "Aveo"
                        },
                        new
                        {
                            Id = 30,
                            BrandId = 9,
                            Name = "Cruze"
                        },
                        new
                        {
                            Id = 31,
                            BrandId = 9,
                            Name = "Volt"
                        },
                        new
                        {
                            Id = 32,
                            BrandId = 10,
                            Name = "CX-3"
                        },
                        new
                        {
                            Id = 33,
                            BrandId = 10,
                            Name = "CX-5"
                        },
                        new
                        {
                            Id = 34,
                            BrandId = 10,
                            Name = "Mazda5"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "slider-1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Image = "slider-2.jpg"
                        });
                });

            modelBuilder.Entity("HarrierFinalProject.Models.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transmissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Back"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Front"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Full"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HarrierFinalProject.Models.Model", b =>
                {
                    b.HasOne("HarrierFinalProject.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}