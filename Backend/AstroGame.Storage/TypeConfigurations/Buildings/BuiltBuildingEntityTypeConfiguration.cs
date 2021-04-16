using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.TypeConfigurations.Buildings
{
    public class BuiltBuildingEntityTypeConfiguration : IEntityTypeConfiguration<BuiltBuilding>
    {
        public void Configure(EntityTypeBuilder<BuiltBuilding> builder)
        {
            builder.ToTable("BuiltBuildings");
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("(newid())");

            builder.HasOne(e => e.Building)
                //.WithMany(e => e.BuiltBuildings)
                .WithMany()
                .HasForeignKey(e => e.BuildingId);

            builder.HasOne(e => e.ColonizedStellarObject)
                .WithMany(e => e.BuiltBuildings)
                .HasForeignKey(e => e.ColonizedStellarObjectId);
        }
    }
}