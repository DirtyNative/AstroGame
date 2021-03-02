﻿using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases.TypeConfigurations.Objects
{
    public class StarEntityTypeConfiguration : IEntityTypeConfiguration<Star>
    {
        public void Configure(EntityTypeBuilder<Star> builder)
        {
            builder.ToTable("Stars");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarObject>();
            builder.HasOne(e => e.ParentSystem)
                .WithOne(e => e.CenterObject as Star).HasForeignKey<SingleObjectSystem>(e => e.CenterObjectId);

            builder.HasOne(e => e.Prefab).WithMany().HasForeignKey(e => e.PrefabId);

            /*builder.HasMany(e => e.Resources).WithOne(e => e.StellarObject as Star)
                .HasForeignKey(e => e.StellarObjectId);*/

            //builder.HasMany(e => e.Resources).WithOne().HasForeignKey(e => e.StellarObjectId);
        }
    }
}