using AstroGame.Shared.Models.Stellar.BaseTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Players
{
    public class ColonizableStellarObjectEntityTypeConfiguration : IEntityTypeConfiguration<ColonizableStellarObject>
    {
        public void Configure(EntityTypeBuilder<ColonizableStellarObject> builder)
        {
            builder.ToTable("ColonizableStellarObjects");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
        }
    }
}
