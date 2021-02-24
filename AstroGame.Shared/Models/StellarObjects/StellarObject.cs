using System.Text.Json.Serialization;
using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Models.StellarObjects
{
    /// <summary>
    /// Anything that can be rendered
    /// </summary>
    public abstract class StellarObject : StellarThing
    {
        protected StellarObject()
        {
        }

        protected StellarObject(StellarSystem parent) : base(parent)
        {
        }

        [JsonIgnore] public virtual SingleObjectSystem Parent { get; set; }

        /// <summary>
        /// The name of Unity's Prefab which can be rendered
        /// </summary>
        public string PrefabName { get; set; }

        public double Scale { get; set; }

        public double RotationSpeed { get; set; }
    }
}