using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases
{
    public class MultiObjectSystemEntityTypeConfiguration : IEntityTypeConfiguration<MultiObjectSystem>
    {
        public void Configure(EntityTypeBuilder<MultiObjectSystem> builder)
        {
            builder.ToTable("MultiObjectSystems");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarSystem>();
            builder.HasOne(e => e.Parent)
                .WithMany().HasForeignKey(e => e.ParentId);
        }
    }
}