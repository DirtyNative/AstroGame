using AstroGame.Shared.Models.StellarSystems;
using System;

namespace AstroGame.Shared.Models
{
    /// <summary>
    /// Defines anything that is available in Cosmos
    /// </summary>
    public abstract class StellarThing
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }

        public virtual string Name { get; set; }

        public virtual StellarSystem Parent { get; set; }

        protected StellarThing()
        {
        }

        protected StellarThing(StellarSystem parent)
        {
            Parent = parent;
        }
    }
}