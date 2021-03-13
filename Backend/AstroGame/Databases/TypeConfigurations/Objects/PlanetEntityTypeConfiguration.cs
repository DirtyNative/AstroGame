using System.Collections.Generic;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Objects
{
    public class PlanetEntityTypeConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.ToTable("Planets");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarObject>();
            builder.HasOne(e => e.ParentSystem)
                .WithMany(e => (IEnumerable<Planet>) e.CenterObjects);


            /*builder.HasMany(e => e.Resources).WithOne(e => e.StellarObject as Planet)
                .HasForeignKey(e => e.StellarObjectId); */

            //builder.HasMany(e => e.Resources).WithOne().HasForeignKey(e => e.StellarObjectId);
        }
    }
}