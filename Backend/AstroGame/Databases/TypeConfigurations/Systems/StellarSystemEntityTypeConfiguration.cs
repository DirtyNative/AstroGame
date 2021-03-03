using AstroGame.Shared.Models.Stellar.BaseTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Api.Databases.TypeConfigurations.Systems
{
    public class StellarSystemEntityTypeConfiguration : IEntityTypeConfiguration<StellarSystem>
    {
        public void Configure(EntityTypeBuilder<StellarSystem> builder)
        {
            builder.ToTable("StellarSystems");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            /*builder.HasOne(e => e.Parent)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction); */
        }
    }
}