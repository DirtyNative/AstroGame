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
    [Migration("20210225092402_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.StellarObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RotationSpeed")
                        .HasColumnType("float");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("StellarObject");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.StellarSystem", b =>
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

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Moon", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarObjects.StellarObject");

                    b.Property<int>("AverageTemperate")
                        .HasColumnType("int");

                    b.Property<double>("DistanceToCenter")
                        .HasColumnType("float");

                    b.Property<bool>("HasRings")
                        .HasColumnType("bit");

                    b.ToTable("Moons");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Planet", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarObjects.StellarObject");

                    b.Property<int>("AverageTemperature")
                        .HasColumnType("int");

                    b.Property<double>("DistanceToCenter")
                        .HasColumnType("float");

                    b.Property<bool>("HasAtmosphere")
                        .HasColumnType("bit");

                    b.Property<bool>("HasRings")
                        .HasColumnType("bit");

                    b.Property<int>("PlanetType")
                        .HasColumnType("int");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Star", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarObjects.StellarObject");

                    b.Property<int>("AverageTemperature")
                        .HasColumnType("int");

                    b.Property<int>("StarType")
                        .HasColumnType("int");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarSystems.StellarSystem");

                    b.ToTable("MultiObjectSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarSystems.StellarSystem");

                    b.Property<Guid>("CenterObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CenterObjectId")
                        .IsUnique()
                        .HasFilter("[CenterObjectId] IS NOT NULL");

                    b.ToTable("SingleObjectSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SolarSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem");

                    b.ToTable("SolarSystems");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.StellarSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", null)
                        .WithMany("CenterSystems")
                        .HasForeignKey("MultiObjectSystemId");

                    b.HasOne("AstroGame.Shared.Models.StellarSystems.StellarSystem", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("AstroGame.Shared.Models.StellarSystems.StellarSystem", null)
                        .WithMany("Satellites")
                        .HasForeignKey("StellarSystemId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Moon", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarObjects.StellarObject", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.StellarObjects.Moon", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Planet", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarObjects.StellarObject", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.StellarObjects.Planet", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Star", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarObjects.StellarObject", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.StellarObjects.Star", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarSystems.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarObjects.StellarObject", "CenterObject")
                        .WithOne("ParentSystem")
                        .HasForeignKey("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", "CenterObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AstroGame.Shared.Models.StellarSystems.StellarSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("CenterObject");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SolarSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", null)
                        .WithOne()
                        .HasForeignKey("AstroGame.Shared.Models.StellarSystems.SolarSystem", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.StellarObject", b =>
                {
                    b.Navigation("ParentSystem");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.StellarSystem", b =>
                {
                    b.Navigation("Satellites");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", b =>
                {
                    b.Navigation("CenterSystems");
                });
#pragma warning restore 612, 618
        }
    }
}
