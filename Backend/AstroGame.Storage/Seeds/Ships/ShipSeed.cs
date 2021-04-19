using AstroGame.Shared.Models.Ships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AstroGame.Storage.Seeds.Ships
{
    public class ShipSeed : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.HasData(new Ship()
            {
                Id = Guid.Parse("D11E09E0-E058-4E2E-8CF0-65A0A79B81BE"),
                Name = "Cargo pod",
                Description = "A small pod to transport some resources",
                StructuralIntegrity = 4000,
                WeaponPower = 0,
                ShieldPower = 10,
                StellarSpeed = 5000,
                InterstellarSpeed = 50000,
                FuelConsumption = 10,
                CargoCapacity = 2000,

                // Hydrogen
                FuelId = Guid.Parse("00000000-1111-0000-0000-000000000001")
            });
        }
    }
}
