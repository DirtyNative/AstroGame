using System;
using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.Seeds.Resources
{
    public class MaterialManufactionSeed : IEntityTypeConfiguration<ResourceManufaction>
    {
        public void Configure(EntityTypeBuilder<ResourceManufaction> builder)
        {
            builder.HasData(
                new ResourceManufaction()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    OutputValue = 1,
                    OutputMaterialId = Guid.Parse("00000000-0000-1111-0000-000000000001"),
                    
                });
        }
    }
}
