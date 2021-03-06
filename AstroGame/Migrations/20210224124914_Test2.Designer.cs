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
    [Migration("20210224124914_Test2")]
    partial class Test2
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrefabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RotationSpeed")
                        .HasColumnType("float");

                    b.Property<double>("Scale")
                        .HasColumnType("float");

                    b.Property<string>("StellarObjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StellarObjects");

                    b.HasDiscriminator<string>("StellarObjectType").HasValue("StellarObject");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.StellarSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MultiObjectSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StellarSystemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MultiObjectSystemId");

                    b.HasIndex("ParentId1");

                    b.ToTable("StellarSystems");

                    b.HasDiscriminator<string>("StellarSystemType").HasValue("StellarSystem");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Moon", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarObjects.StellarObject");

                    b.Property<int>("AverageTemperate")
                        .HasColumnType("int");

                    b.Property<double>("DistanceToCenter")
                        .HasColumnType("float")
                        .HasColumnName("Moon_DistanceToCenter");

                    b.Property<bool>("HasRings")
                        .HasColumnType("bit")
                        .HasColumnName("Moon_HasRings");

                    b.HasDiscriminator().HasValue("Moon");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Planet", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarObjects.StellarObject");

                    b.Property<int>("AverageTemperature")
                        .HasColumnType("int")
                        .HasColumnName("Planet_AverageTemperature");

                    b.Property<double>("DistanceToCenter")
                        .HasColumnType("float");

                    b.Property<bool>("HasAtmosphere")
                        .HasColumnType("bit");

                    b.Property<bool>("HasRings")
                        .HasColumnType("bit");

                    b.Property<int>("PlanetType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Planet");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.Star", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarObjects.StellarObject");

                    b.Property<int>("AverageTemperature")
                        .HasColumnType("int");

                    b.Property<int>("StarType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Star");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarSystems.StellarSystem");

                    b.HasDiscriminator().HasValue("Multi");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarSystems.StellarSystem");

                    b.HasIndex("ParentId")
                        .IsUnique()
                        .HasFilter("[ParentId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Single");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SolarSystem", b =>
                {
                    b.HasBaseType("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem");

                    b.HasDiscriminator().HasValue("SolarSystem");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.StellarSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarSystems.MultiObjectSystem", null)
                        .WithMany("CenterSystems")
                        .HasForeignKey("MultiObjectSystemId");

                    b.HasOne("AstroGame.Shared.Models.StellarSystems.StellarSystem", "Parent")
                        .WithMany("Satellites")
                        .HasForeignKey("ParentId1");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", b =>
                {
                    b.HasOne("AstroGame.Shared.Models.StellarObjects.StellarObject", "CenterObject")
                        .WithOne("Parent")
                        .HasForeignKey("AstroGame.Shared.Models.StellarSystems.SingleObjectSystem", "ParentId");

                    b.Navigation("CenterObject");
                });

            modelBuilder.Entity("AstroGame.Shared.Models.StellarObjects.StellarObject", b =>
                {
                    b.Navigation("Parent");
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
