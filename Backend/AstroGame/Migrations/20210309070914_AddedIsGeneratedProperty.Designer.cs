﻿// <auto-generated />
using System;
using AstroGame.Api.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AstroGame.Api.Migrations
{
    [DbContext(typeof(AstroGameDataContext))]
    [Migration("20210309070914_AddedIsGeneratedProperty")]
    partial class AddedIsGeneratedProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.InputResource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<double>("InputValue")
                        .HasColumnType("float");

                    b.Property<Guid>("OutputMaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OutputMaterialId");

                    b.HasIndex("ResourceId");

                    b.ToTable("InputResources");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            InputValue = 2.0,
                            OutputMaterialId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ResourceId = new Guid("00000000-1111-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            InputValue = 2.0,
                            OutputMaterialId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ResourceId = new Guid("00000000-1111-0000-0000-000000000008")
                        });
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NaturalOccurrenceWeight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.ResourceManufaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("OutputMaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("OutputValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OutputMaterialId")
                        .IsUnique();

                    b.ToTable("ResourceManufactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            OutputMaterialId = new Guid("00000000-0000-1111-0000-000000000001"),
                            OutputValue = 1.0
                        });
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.StellarObjectResource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("MoonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Multiplier")
                        .HasColumnType("float");

                    b.Property<Guid?>("PlanetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StellarObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MoonId");

                    b.HasIndex("PlanetId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("StarId");

                    b.HasIndex("StellarObjectId");

                    b.ToTable("StellarObjectResources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AverageDistanceToCenter")
                        .HasColumnType("float");

                    b.Property<int>("AverageTemperature")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParentSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("RotationSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ParentSystemId")
                        .IsUnique();

                    b.ToTable("StellarObjects");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("GalaxyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MultiObjectSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MultiObjectSystemId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SingleObjectSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SolarSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SolarSystemId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GalaxyId");

                    b.HasIndex("MultiObjectSystemId");

                    b.HasIndex("MultiObjectSystemId1");

                    b.HasIndex("SingleObjectSystemId");

                    b.HasIndex("SolarSystemId");

                    b.HasIndex("SolarSystemId1");

                    b.ToTable("StellarSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Element", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Resources.Resource");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000001"),
                            Name = "Hydrogen",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "H",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000002"),
                            Name = "Helium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "He",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000003"),
                            Name = "Lithium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Li",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000004"),
                            Name = "Beryllium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Be",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000005"),
                            Name = "Boron",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "B",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000006"),
                            Name = "Carbon",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "C",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000007"),
                            Name = "Nitrogen",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "N",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000008"),
                            Name = "Oxygen",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "O",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000009"),
                            Name = "Magnesium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Mg",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000010"),
                            Name = "Aluminium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Al",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000011"),
                            Name = "Silicon",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Si",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000012"),
                            Name = "Phosphorus",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "P",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000013"),
                            Name = "Sulfur",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "S",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000014"),
                            Name = "Chlorine",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Cl",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000015"),
                            Name = "Titanium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Ti",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000016"),
                            Name = "Iron",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Fe",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000017"),
                            Name = "Cobalt",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Co",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000018"),
                            Name = "Nickel",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Ni",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000019"),
                            Name = "Copper",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Cu",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000020"),
                            Name = "Zinc",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Zn",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000021"),
                            Name = "Gallium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Ga",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000022"),
                            Name = "Germanium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Ge",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000023"),
                            Name = "Palladium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Pd",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000024"),
                            Name = "Silver",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Ag",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000025"),
                            Name = "Tin",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Sn",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000026"),
                            Name = "Iridium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Ir",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000027"),
                            Name = "Platinum",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Pt",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000028"),
                            Name = "Gold",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Au",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-0000-0000-000000000029"),
                            Name = "Plutonium",
                            NaturalOccurrenceWeight = 1L,
                            Symbol = "Pu",
                            Type = 1
                        });
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Material", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Resources.Resource");

                    b.Property<Guid?>("ManufactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-1111-0000-000000000001"),
                            Name = "Water",
                            NaturalOccurrenceWeight = 1L,
                            ManufactionId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-1111-0000-000000000002"),
                            Name = "Food",
                            NaturalOccurrenceWeight = 1L,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-1111-0000-000000000003"),
                            Name = "Luxury Goods",
                            NaturalOccurrenceWeight = 1L,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-1111-0000-000000000001"),
                            Name = "Conductive Components",
                            NaturalOccurrenceWeight = 1L,
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-1111-0000-000000000002"),
                            Name = "Conductive Components",
                            NaturalOccurrenceWeight = 1L,
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("00000000-1111-1111-0000-000000000003"),
                            Name = "Supra conductors",
                            NaturalOccurrenceWeight = 1L,
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("00000000-2222-1111-0000-000000000001"),
                            Name = "Deuterium",
                            NaturalOccurrenceWeight = 1L,
                            Type = 4
                        },
                        new
                        {
                            Id = new Guid("00000000-2222-1111-0000-000000000002"),
                            Name = "Tritium",
                            NaturalOccurrenceWeight = 1L,
                            Type = 4
                        },
                        new
                        {
                            Id = new Guid("00000000-3333-1111-0000-000000000001"),
                            Name = "Hardened Iron",
                            NaturalOccurrenceWeight = 0L,
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-3333-1111-0000-000000000002"),
                            Name = "Steel",
                            NaturalOccurrenceWeight = 0L,
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-3333-1111-0000-000000000003"),
                            Name = "Nanites",
                            NaturalOccurrenceWeight = 0L,
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-4444-1111-0000-000000000001"),
                            Name = "Reactive alloys",
                            NaturalOccurrenceWeight = 0L,
                            Type = 3
                        },
                        new
                        {
                            Id = new Guid("00000000-4444-1111-0000-000000000002"),
                            Name = "Nano alloys",
                            NaturalOccurrenceWeight = 0L,
                            Type = 3
                        },
                        new
                        {
                            Id = new Guid("00000000-5555-1111-0000-000000000001"),
                            Name = "Dark matter",
                            NaturalOccurrenceWeight = 0L,
                            Type = 0
                        });
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Moon", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject");

                    b.Property<double>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.ToTable("Moons");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Planet", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject");

                    b.Property<double>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<bool>("HasHabitableAtmosphere")
                        .HasColumnType("bit");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.Property<int>("PlanetType")
                        .HasColumnType("int");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Star", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject");

                    b.Property<double>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.Property<int>("StarType")
                        .HasColumnType("int");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.Galaxy", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem");

                    b.ToTable("Galaxies");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ParentId");

                    b.ToTable("MultiObjectSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem");

                    b.Property<Guid>("CenterObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ParentId");

                    b.ToTable("SingleObjectSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem");

                    b.Property<bool>("IsGenerated")
                        .HasColumnType("bit");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SystemNumber")
                        .HasColumnType("bigint");

                    b.HasIndex("ParentId");

                    b.ToTable("SolarSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.InputResource", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Resources.ResourceManufaction", "Output")
                        .WithMany("InputResources")
                        .HasForeignKey("OutputMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstroGame.Shared.Models.Resources.Resource", "Input")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Input");

                    b.Navigation("Output");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.ResourceManufaction", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Resources.Material", "OutputMaterial")
                        .WithOne("Manufaction")
                        .HasForeignKey("AstroGame.Shared.Models.Resources.ResourceManufaction", "OutputMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OutputMaterial");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.StellarObjectResource", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarObjects.Moon", null)
                        .WithMany("Resources")
                        .HasForeignKey("MoonId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarObjects.Planet", null)
                        .WithMany("Resources")
                        .HasForeignKey("PlanetId");

                    b.HasOne("AstroGame.Shared.Models.Resources.Resource", "Resource")
                        .WithMany("StellarObjectResources")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarObjects.Star", null)
                        .WithMany("Resources")
                        .HasForeignKey("StarId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", "StellarObject")
                        .WithMany()
                        .HasForeignKey("StellarObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("StellarObject");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", "ParentSystem")
                        .WithOne("CenterObject")
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", "ParentSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentSystem");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.Galaxy", null)
                        .WithMany("Systems")
                        .HasForeignKey("GalaxyId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", null)
                        .WithMany("CenterSystems")
                        .HasForeignKey("MultiObjectSystemId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", null)
                        .WithMany("Satellites")
                        .HasForeignKey("MultiObjectSystemId1");

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", null)
                        .WithMany("Satellites")
                        .HasForeignKey("SingleObjectSystemId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", null)
                        .WithMany("CenterSystems")
                        .HasForeignKey("SolarSystemId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", null)
                        .WithMany("Satellites")
                        .HasForeignKey("SolarSystemId1");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Element", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Resources.Resource", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Resources.Element", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Material", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Resources.Resource", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Resources.Material", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Moon", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarObjects.Moon", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Planet", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarObjects.Planet", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Star", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarObjects.Star", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.Galaxy", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.Galaxy", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Resource", b =>
                {
                    b.Navigation("StellarObjectResources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.ResourceManufaction", b =>
                {
                    b.Navigation("InputResources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Resources.Material", b =>
                {
                    b.Navigation("Manufaction");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Moon", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Planet", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Star", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.Galaxy", b =>
                {
                    b.Navigation("Systems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", b =>
                {
                    b.Navigation("CenterSystems");

                    b.Navigation("Satellites");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", b =>
                {
                    b.Navigation("CenterObject");

                    b.Navigation("Satellites");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", b =>
                {
                    b.Navigation("CenterSystems");

                    b.Navigation("Satellites");
                });
#pragma warning restore 612, 618
        }
    }
}
