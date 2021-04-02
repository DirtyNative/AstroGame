using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AstroGame.Storage.TypeConfigurations.Objects
{
    public class PlanetEntityTypeConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.ToTable("Planets");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<ColonizableStellarObject>();
            builder.HasOne(e => e.ParentSystem)
                .WithMany(e => (IEnumerable<Planet>) e.CenterObjects);

            builder.HasOne(e => e.ColonizedStellarObject)
                .WithOne(e => e.ColonizableStellarObject as Planet)
                .HasForeignKey<Planet>(e => e.ColonizedStellarObjectId);
            
            /*builder.HasMany(e => e.StoredResources).WithOne(e => e.StellarObject as Planet)
                .HasForeignKey(e => e.StellarObjectId); */

            //builder.HasMany(e => e.StoredResources).WithOne().HasForeignKey(e => e.StellarObjectId);
        }
    }
}