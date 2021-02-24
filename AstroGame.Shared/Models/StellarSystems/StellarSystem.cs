using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AstroGame.Shared.Models.StellarSystems
{
    /// <summary>
    /// Any construct in space that consists of multiple <see cref="StellarThing"/>
    /// </summary>
    public abstract class StellarSystem : StellarThing
    {
        protected StellarSystem()
        {
        }

        protected StellarSystem(StellarSystem parent) : base(parent)
        {
        }

        [JsonIgnore] public virtual StellarSystem Parent { get; set; }

        public override string Name => Parent?.Name;

        /// <summary>
        /// The position relative to the parent.
        /// 1: first sub object
        /// 2: second sub object
        /// ...
        /// </summary>
        public int Order { get; set; }

        public List<StellarSystem> Satellites { get; set; }
    }
}