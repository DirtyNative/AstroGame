using System.Collections.Generic;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Objects
{
    public class BlackHoleEntityTypeConfiguration : IEntityTypeConfiguration<BlackHole>
    {
        public void Configure(EntityTypeBuilder<BlackHole> builder)
        {
            builder.ToTable("BlackHoles");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarObject>();
            builder.HasOne(e => e.ParentSystem).WithMany(e => (IEnumerable<BlackHole>) e.CenterObjects);
        }
    }
}