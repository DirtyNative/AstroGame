using System.Collections.Generic;

namespace AstroGame.Shared.Models.Buildings
{
    public interface IProducingBuilding
    {
        /// <summary>
        /// The resources which get produces per hour
        /// </summary>
        List<OutputResource> OutputResources { get; set; }
    }
}