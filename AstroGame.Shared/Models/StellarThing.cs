using AstroGame.Shared.Models.StellarSystems;
using System;

namespace AstroGame.Shared.Models
{
    /// <summary>
    /// Defines anything that is available in Cosmos
    /// </summary>
    public interface StellarThing
    {
        Guid Id { get; set; }
        Guid? ParentId { get; set; }

        string Name { get; set; }
    }
}