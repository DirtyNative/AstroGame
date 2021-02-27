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
    [Migration("20210226192730_PrefabGenerationTest")]
    partial class PrefabGenerationTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.Prefab", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prefab");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

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

                    b.ToTable("StellarObject");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("MultiObjectSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StellarSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MultiObjectSystemId");

                    b.HasIndex("ParentId");

                    b.HasIndex("StellarSystemId");

                    b.ToTable("StellarSystem");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.MoonPrefab", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Prefabs.Prefab");

                    b.Property<string>("Offset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MoonPrefabs");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.PlanetPrefab", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Prefabs.Prefab");

                    b.Property<string>("Offset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanetType")
                        .HasColumnType("int");

                    b.Property<string>("Rotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("PlanetPrefabs");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.StarPrefab", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Prefabs.Prefab");

                    b.Property<string>("Offset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarType")
                        .HasColumnType("int");

                    b.ToTable("StarPrefabs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "Test_Prefab",
                            Offset = "(0.0, 0.0, -1.0)",
                            Rotation = "(-1.0, 0.0, 0.0)",
                            Scale = "(0.0, 0.0, 0.0)",
                            StarType = 0
                        });
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Moon", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject");

                    b.Property<double>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<bool>("HasRings")
                        .HasColumnType("bit");

                    b.Property<Guid>("PrefabId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.ToTable("Moons");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Planet", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject");

                    b.Property<double>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<bool>("HasAtmosphere")
                        .HasColumnType("bit");

                    b.Property<bool>("HasRings")
                        .HasColumnType("bit");

                    b.Property<int>("PlanetType")
                        .HasColumnType("int");

                    b.Property<Guid>("PrefabId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrefabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarObjects.Star", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarObject");

                    b.Property<double>("AxialTilt")
                        .HasColumnType("float");

                    b.Property<Guid>("PrefabId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.Property<int>("StarType")
                        .HasColumnType("int");

                    b.HasIndex("PrefabId");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem");

                    b.ToTable("MultiObjectSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem");

                    b.Property<Guid>("CenterObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("SingleObjectSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem");

                    b.ToTable("SolarSystems");
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
                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", null)
                        .WithMany("CenterSystems")
                        .HasForeignKey("MultiObjectSystemId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithMany("Satellites")
                        .HasForeignKey("StellarSystemId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.MoonPrefab", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Prefabs.Prefab", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Prefabs.MoonPrefab", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.PlanetPrefab", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Prefabs.Prefab", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Prefabs.PlanetPrefab", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Prefabs.StarPrefab", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Prefabs.Prefab", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Prefabs.StarPrefab", "Id")
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

                    b.HasOne("AstroGame.Shared.Models.Prefabs.StarPrefab", "Prefab")
                        .WithMany()
                        .HasForeignKey("PrefabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prefab");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.Stellar.StellarSystems.SolarSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.BaseTypes.StellarSystem", b =>
                {
                    b.Navigation("Satellites");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.MultiObjectSystem", b =>
                {
                    b.Navigation("CenterSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.Stellar.StellarSystems.SingleObjectSystem", b =>
                {
                    b.Navigation("CenterObject");
                });
#pragma warning restore 612, 618
        }
    }
}
