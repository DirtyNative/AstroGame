using System.Numerics;
using AstroGame.Shared.Models.StellarObjects;
using AstroGame.Shared.Models.StellarSystems;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Api.Databases
{
    public class AstroGameDataContext : DbContext
    {
        public AstroGameDataContext()
        {
        }

        public AstroGameDataContext(DbContextOptions<AstroGameDataContext> options) : base(options)
        {
        }

        public DbSet<Moon> Moons { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<MultiObjectSystem> MultiObjectSystems { get; set; }
        public DbSet<SingleObjectSystem> SingleObjectSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // StellarObject
            modelBuilder.Entity<StellarObject>().ToTable("StellarObjects").HasDiscriminator<string>("StellarObjectType")
                .HasValue<Moon>("Moon")
                .HasValue<Planet>("Planet")
                .HasValue<Star>("Star");

            modelBuilder.Entity<StellarObject>().HasOne(e => e.Parent).WithOne(e => e.CenterObject)
                .HasForeignKey<SingleObjectSystem>(e => e.ParentId);

            // Stellar System
            modelBuilder.Entity<StellarSystem>().ToTable("StellarSystems").HasDiscriminator<string>("StellarSystemType")
                .HasValue<MultiObjectSystem>("Multi")
                .HasValue<SingleObjectSystem>("Single");

            /*
            // Moon
            modelBuilder.Entity<Moon>(entity =>
            {
                entity.ToTable("Moons");
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            });

            //modelBuilder.Entity<Moon>().HasBaseType<StellarObject>();
            modelBuilder.Entity<Moon>().HasDiscriminator<string>("moon_type").HasValue<Moon>("moon")
                .HasValue<StellarObject>("stellar_object");

            // Planet
            modelBuilder.Entity<Planet>(entity =>
            {
                entity.ToTable("Planets");
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Planet>().HasBaseType<StellarObject>();

            modelBuilder.Entity<Planet>().HasOne(e => e.Parent)
                .WithMany().HasForeignKey(e => e.ParentId);

            // Star
            modelBuilder.Entity<Star>(entity =>
            {
                entity.ToTable("Stars");
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Star>().HasBaseType<StellarObject>();

            modelBuilder.Entity<Star>().HasOne(e => e.Parent)
                .WithMany().HasForeignKey(e => e.ParentId);

            // SolarSystem
            modelBuilder.Entity<SolarSystem>(entity =>
            {
                entity.ToTable("SolarSystems");
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SolarSystem>().HasBaseType<MultiObjectSystem>();

            // Multi object system
            modelBuilder.Entity<MultiObjectSystem>(entity =>
            {
                entity.ToTable("MultiObjectSystems");
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<MultiObjectSystem>().HasBaseType<StellarSystem>();

            modelBuilder.Entity<MultiObjectSystem>().HasOne(e => e.Parent)
                .WithMany().HasForeignKey(e => e.ParentId);


            // Single object system
            modelBuilder.Entity<SingleObjectSystem>(entity =>
            {
                entity.ToTable("SingleObjectSystems");
                entity.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SingleObjectSystem>().HasBaseType<StellarSystem>();

            modelBuilder.Entity<SingleObjectSystem>().HasOne(e => e.Parent)
                .WithMany().HasForeignKey(e => e.ParentId);
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}