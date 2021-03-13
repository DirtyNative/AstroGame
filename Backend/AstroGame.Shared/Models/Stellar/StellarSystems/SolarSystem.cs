using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Stellar.StellarSystems
{
    public class SolarSystem : MultiObjectSystem
    {
        public SolarSystem()
        {
        }

        public SolarSystem(StellarSystem parent)
        {
            Parent = parent;
        }

        public override string Name { get; set; }

        /// <summary>
        /// The position in 3D space
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// <para>Indicates if this system is generated</para>
        /// <para>Because the galaxy is not generated recursively, the solar systems need to be generated on demand</para>
        /// </summary>
        public bool IsGenerated { get; set; }
    }
}