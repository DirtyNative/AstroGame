using AstroGame.Shared.Models.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroGame.Storage.Seeds.Resources
{
    public class InputResourceSeed : IEntityTypeConfiguration<InputResource>
    {
        public void Configure(EntityTypeBuilder<InputResource> builder)
        {
            
        }
    }
}