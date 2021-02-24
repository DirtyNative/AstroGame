using System;

namespace AstroGame.Shared.Models
{
    /// <summary>
    /// Defines anything that is available in Cosmos
    /// </summary>
    public abstract class StellarThing
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        protected StellarThing()
        {
        }
    }
}