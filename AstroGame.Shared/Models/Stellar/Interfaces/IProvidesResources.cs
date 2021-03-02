using AstroGame.Shared.Models.Resources;
using System.Collections.Generic;

namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    public interface IProvidesResources
    {
        List<StellarObjectResource> Resources { get; set; }
    }
}