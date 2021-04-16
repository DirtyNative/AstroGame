using System.Collections.Generic;

namespace AstroGame.Shared.Models.Buildings
{
    public interface IConsumingBuilding
    {
        /// <summary>
        ///  The resources which get consumed per hour
        /// </summary>
        List<InputResource> InputResources { get; set; }
    }
}