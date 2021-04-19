using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    // public class BuildingEntityTypeConfiguration : IEntityTypeConfiguration<Building>
    // {
    //     public void Configure(EntityTypeBuilder<Building> builder)
    //     {
    //         builder.ToTable("Buildings");
    //         //builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");
    //         
    //         builder.HasMany(e => e.InputResources)
    //             .WithOne(e => e.Building)
    //             .HasForeignKey(e => e.BuildingId);
    //
    //         builder.HasMany(e => e.OutputResources)
    //             .WithOne(e => e.Building)
    //             .HasForeignKey(e => e.BuildingId);
    //     }
    // }
}
