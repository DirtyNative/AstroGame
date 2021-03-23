using System;

namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    public interface IColonizable
    {
        /// <summary>
        /// The id of a users colonization
        /// </summary>
        public Guid? ColonizedStellarObjectId { get; set; }
    }
}
