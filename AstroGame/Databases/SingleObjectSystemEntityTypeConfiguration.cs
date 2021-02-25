﻿using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Api.Databases
{
    public class SingleObjectSystemEntityTypeConfiguration : IEntityTypeConfiguration<SingleObjectSystem>
    {
        public void Configure(EntityTypeBuilder<SingleObjectSystem> builder)
        {
            builder.ToTable("SingleObjectSystems");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
            builder.HasBaseType<StellarSystem>();
            builder.HasOne(e => e.Parent)
                .WithMany().HasForeignKey(e => e.ParentId);
        }
    }
}