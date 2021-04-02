using System.Collections.Generic;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Objects
{
    public class MoonEntityTypeConfiguration : IEntityTypeConfiguration<Moon>
    {
        public void Configure(EntityTypeBuilder<Moon> builder)
        {
            builder.ToTable("Moons");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarObject>();

            builder.HasOne(e => e.ParentSystem)
                .WithMany(e => (IEnumerable<Moon>) e.CenterObjects);

            /*builder.HasMany(e => e.StoredResources).WithOne(e => e.StellarObject as Moon)
                .HasForeignKey(e => e.StellarObjectId); */

            //builder.HasMany(e => e.StoredResources).WithOne().HasForeignKey(e => e.StellarObjectId);
        }
    }
}