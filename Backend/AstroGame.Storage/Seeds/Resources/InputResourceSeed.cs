using System;
using AstroGame.Shared.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.Seeds.Resources
{
    public class InputResourceSeed : IEntityTypeConfiguration<InputResource>
    {
        public void Configure(EntityTypeBuilder<InputResource> builder)
        {
            builder.HasData(new InputResource()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000001"),
                    InputValue = 2,
                    OutputMaterialId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                new InputResource()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ResourceId = Guid.Parse("00000000-1111-0000-0000-000000000008"),
                    InputValue = 2,
                    OutputMaterialId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                }
            );
        }
    }
}